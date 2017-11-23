using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Exceptions;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class Dialoguetests
    {
        [TestMethod]
        public void DialogueClose()
        {
            //Assemble
            Dialogue EndDialogue = new Dialogue(2, "this is the end Dialogue", new List<Choice>());
            List<Choice> choicesStartDialogue = new List<Choice>() {new Choice(1,"close",EndDialogue)};
            Dialogue StartDialogue = new Dialogue(1, "blahblah",choicesStartDialogue);
            //Act
            Dialogue CurrentDialogue = StartDialogue.Choose(1);
            //Assert
            Assert.AreEqual(CurrentDialogue.Close(), true,"close is false");
            Assert.AreSame(CurrentDialogue, EndDialogue, "current Dialogue is not EndDialogue");
        }
        [TestMethod]
        public void DialogueFaultyChoise()
        {
            //Assemble
            Dialogue EndDialogue = new Dialogue(2, "asd", new List<Choice>());
            List<Choice> choicesStartDialogue = new List<Choice>() { new Choice(1, "close", EndDialogue) };
            Dialogue StartDialogue = new Dialogue(1, "blahblah", choicesStartDialogue);
            //Act
            try
            {
                Dialogue CurrentDialogue = StartDialogue.Choose(2);
            }
            catch (ChoiceDoesNotExistException)
            {
                return; 
            }
            //Assert
            Assert.Fail();
        }
    }
}
