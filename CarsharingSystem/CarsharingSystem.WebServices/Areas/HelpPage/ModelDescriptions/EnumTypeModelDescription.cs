namespace CarsharingSystem.WebServices.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    using CarsharingSystem.WebServices.Areas.HelpPage.ModelDescriptions;

    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            this.Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}