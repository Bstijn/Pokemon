using Classes.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classes
{
    public class Dialogue
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public List<Choice> Choices { get; private set; }
        public bool ClosingDialogue { get; private set; }

        public Dialogue(int id, string text, List<Choice> choices)//Propably need to limit choices for unity so it doesnt get errors.
        {
            this.Id = id;
            this.Text = text;
            this.Choices = choices;
        }
        public Dialogue()//For now 2 constructer dont know how it'll work with the database.
        {

        }
        public Dialogue Choose(int choiceId)////TODO Stijn: verwerk exception in Unity ||Checks if one of the choises has the given Id if not there is something wrong with the given Id wich should propably not occur, so an exception will be thrown.
        {
            foreach (Choice choice in Choices)
            {
                if (choice.Id == choiceId)
                {
                    return choice.LeadsToDialogue;
                }
                
            }
            throw new ChoiceDoesNotExistException();
            
        }
        public bool Close()//TODO Stijn: verwerk dit in Unity || returns a boolean that will be called everytime a new dialogue will be opened if this returns true in unity it will setActive(False) the GameObject.
        {
            if (Choices.Count== 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
