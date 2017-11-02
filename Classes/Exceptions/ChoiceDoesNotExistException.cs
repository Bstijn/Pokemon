using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Exceptions
{
    public class ChoiceDoesNotExistException: Exception
    {
        public ChoiceDoesNotExistException(): base("the Choice does not exist for this dialogue or doesnt exist at all. Problem most likely in database.")
        {

        }
    }
}
