using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one_to_one
{
   public class UserProfile
    {
        /*
         * В этой связи между классами класс UserProfile является дочерним 
         * или подчиненным по отношению к классу User. 
         * И чтобы установить связь одни к одному,
         *  у подчиненного класса устанавливается свойство идентификатора,
         *   которое называется также, как и идентификатор в основном классе. 
         *   То есть в классе User свойство называется Id, 
         *   то и в UserProfile также свойство называется Id. 
         *   Если бы в классе User свойство называлось бы UserId,
         *    то такое же название должно было быть и в UserProfile.

            И в классе UserProfile над этим свойством Id устанавливаются два атрибута: 
            [Key], который показывает, то это первичный ключ, 
            и [ForeignKey], который показывает, что это также и внешний ключ.
            Причем внешний ключ к таблице объектов User.
         
         * */

        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public User User { get; set; }

    }
}
