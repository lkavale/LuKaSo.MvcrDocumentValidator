namespace LuKaSo.MvcrDocumentValidator.Documents
{
    /// <summary>
    /// Document type
    /// </summary>
    public enum DocumentTypeRequest
    {
        // Pro občanský průkaz se používá 0 (nula)
        IdentityCard = 0,

        // Hodnota 4 znamená centrálně vydávaný cestovní pas, poznáte jej podle fialové barvy
        PurplePassport = 4,

        // Číslo 5 označuje cestovní pas vydaný okresním úřadem, poznáte jej podle zelené barvy
        GeenPassport = 5,

        // Číslo 6 označuje zbrojní průkaz
        GunLicense = 6    
    }
}
