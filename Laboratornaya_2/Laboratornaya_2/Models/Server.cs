using System;
using System.Collections.Generic;
using System.Threading;

namespace Laboratornaya_2.Models
{
    public class Server
    {
        private long _id;
        public static Random random;

        public Server(long id)
        {
            this._id = id;
        }

        /// <summary>
        /// Возвращает информацию о своей загруженности
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<long, string> ReturnInfo()
        {
            if(random == null)
            random = new Random();
            //останавливает работу функции на какое то время, имитация работы
            Thread.Sleep(random.Next(500,4000));
            return new KeyValuePair<long, string>(_id, string.Format(" CPU - {0}%, RAM - {1}% ", random.Next(0, 100), random.Next(0, 100)));
        }

        public override string ToString()
        {
            return _id.ToString();
        }
    }
}
