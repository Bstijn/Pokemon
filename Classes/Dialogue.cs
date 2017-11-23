using Classes.Exceptions;
using System.Collections.Generic;


namespace Classes
{
    public class Dialogue
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public bool ClosingDialogue { get; private set; }

        public Dialogue(int id, string text)//Propably need to limit choices for unity so it doesnt get errors.
        {
            this.Id = id;
            this.Text = text;
        }
        public Dialogue()//For now 2 constructer dont know how it'll work with the database.
        {

        }

        //public bool Close()//TODO Stijn: verwerk dit in Unity || returns a boolean that will be called everytime a new dialogue will be opened if this returns true in unity it will setActive(False) the GameObject.
        //{
        //    if (Choices.Count== 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
