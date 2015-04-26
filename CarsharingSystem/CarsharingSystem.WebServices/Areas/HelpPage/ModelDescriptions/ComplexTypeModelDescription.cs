namespace CarsharingSystem.WebServices.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    using CarsharingSystem.WebServices.Areas.HelpPage.ModelDescriptions;

    public class ComplexTypeModelDescription : ModelDescription
    {
        public ComplexTypeModelDescription()
        {
            this.Properties = new Collection<ParameterDescription>();
        }

        public Collection<ParameterDescription> Properties { get; private set; }
    }
}