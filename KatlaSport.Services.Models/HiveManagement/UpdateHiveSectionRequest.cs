using FluentValidation.Attributes;

namespace KatlaSport.Services.HiveManagement
{
    [Validator(typeof(UpdateHiveSectionRequestValidator))]
    public class UpdateHiveSectionRequest
    {
        /// <summary>
        /// Gets or sets a store hive name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a store hive code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets a store hive code.
        /// </summary>
        public int StoreHiveId { get; set; }
    }
}
