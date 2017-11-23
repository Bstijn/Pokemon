using System;

namespace Classes.Exceptions
{
    public class ChoiceDoesNotExistException: Exception
    {
        public ChoiceDoesNotExistException(): base("the Choice does not exist for this dialogue or doesnt exist at all. Problem most likely in database.")
        {

        }
    }
}
