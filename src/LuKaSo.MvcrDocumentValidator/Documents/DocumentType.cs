namespace LuKaSo.MvcrDocumentValidator.Documents
{
    /// <summary>
    /// Full document type
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// Hodnota „OP“ se užívá pro občanský průkaz bez označení série (nový typ občanského průkazu)
        /// </summary>
        IdentityCardNew,

        /// <summary>
        /// Hodnota „OPs“ označuje občanský průkaz obsahující sérii (starší typ občanského průkazu)
        /// </summary>
        IdentityCardOld,

        /// <summary>
        /// Cestovní pas vydávaný centrálně (fialový pas) má označení „CD“
        /// </summary>
        PurplePassport,

        /// <summary>
        /// Pro cestovní pas vydávaný regionálně (zelený pas) se užívá „CDr“
        /// </summary>
        GeenPassport,

        /// <summary>
        /// Pro případné jiné typy cestovních dokladů je rezervováno označení „CDj“
        /// </summary>
        OtherPassport,

        /// <summary>
        /// ZP 
        /// </summary>
        GunLicense
    }
}
