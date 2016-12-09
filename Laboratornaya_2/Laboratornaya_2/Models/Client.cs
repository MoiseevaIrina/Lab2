using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
//Сбор параметров серверов собрать данные о загруженности
namespace Laboratornaya_2.Models
{
    public static class Client
    {
        /// <summary>
        /// Хранит информацию: Id сервера - параметры
        /// Тип - многопотоковый словарь, так как у нас будет много потоков, это используется
        /// для безпасности
        /// </summary>
        private static ConcurrentDictionary<long, string> _store = new ConcurrentDictionary<long, string>();

        /// <summary>
        /// Ссылка на функцию которая выводит сообщение
        /// </summary>
        public static Action<string> PrintFn;

        public async static void GetInfoFromServer(Server server)
        {
            //запуск асинхронной операции, т.е. клиент отправляет запросы серверам асинхронно
            await Task.Run(() =>
            {
                PrintFn?.Invoke("Запрос значений у сервера " + server.ToString() + Environment.NewLine);

                var response = server.ReturnInfo();
                //данные помещаются в хранилище
                _store.TryAdd(response.Key, response.Value);

                string value = string.Empty;
                if (_store.TryRemove(response.Key, out value))
                {
                    Thread.Sleep(1000);
                    PrintFn?.Invoke(string.Format("Ответ от сервера - {0}. Его Id - {1}" + Environment.NewLine,value, response.Key));
                }
                else
                {
                    PrintFn?.Invoke("Ошибка.");
                }
            });
        }

        private static void PrintToOutput(string text)
        {
            PrintFn?.Invoke(text);
        }
    }
}
