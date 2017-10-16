using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parallelizm.Models
{
    public class Person
    {

        /*
         * Атрибут Timestamp указывает, что значение свойства RowVersion будет включаться в
         *  создаваемое Entity Frameworkом SQL-выражение Where при отправке в базу данных команд на обновление
         *   и удаление. В качестве типа для свойства используется массив байтов.

Также на представлении для редактирования надо добавить скрытое поле для хранения значения новго свойства:
         *  @Html.HiddenFor(model => model.RowVersion)
         * */

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}