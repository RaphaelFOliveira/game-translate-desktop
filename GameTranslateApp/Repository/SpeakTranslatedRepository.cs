using GameTranslateApp.Infra.Database;
using GameTranslateApp.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTranslateApp.Repository
{
    internal class SpeakTranslatedRepository
    {
        private readonly MySqlConnection _cnn;

        public SpeakTranslatedRepository(ApplicationMySqlConnection cnn)
        {
            _cnn = cnn.ConnectionDbGameTranslate();
        }

        public async Task<List<Translation>> GetNewTranslation(Translation translation)
        {
            await _cnn.OpenAsync();

            MySqlCommand command = new MySqlCommand($@"
                                                        select tr.id, 
                                                        tr.text 
                                                        from translate tr
                                                        where tr.Read = 0
                                                        order by tr.created", _cnn
                                                    );

            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                List<Translation> translationList = new List<Translation>();
                
                while (await reader.ReadAsync())
                {
                    translation.Id = int.Parse(reader["id"].ToString());
                    translation.Text = reader["text"].ToString();

                    translationList.Add(new Translation()
                    {
                        Id = translation.Id,
                        Text = translation.Text,
                        Read = translation.Read
                    });
                }

               await _cnn.CloseAsync();
                return translationList;
            }

           await _cnn.CloseAsync();
            return null;
        }

        public async Task UpdateTranslationRead(int id)
        {
            await _cnn.OpenAsync();

            MySqlCommand command = new MySqlCommand($@"
                                                    update translate tr
                                                    set tr.Read = 1
                                                    where tr.id = {id}  ", _cnn);

            await command.ExecuteReaderAsync();
            await _cnn.CloseAsync();
        }
    }
}
