using System;

namespace BusinessLogic.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class TranslationAttribute : Attribute
    {
        public TranslationAttribute(string russianTranslation)
        {
            this.Translation = russianTranslation;
        }

        public string Translation { get; }
    }
}
