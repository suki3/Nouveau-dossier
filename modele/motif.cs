namespace nisab.Desktop.Nouveau_dossier.modele
{
    public class newclass
    {
        
    }
}
namespace mediatek86.modele
{
    /// <summary>
     /// créér un motif
     /// </summary>
}
 public class Motif
    {
        // declaration des propriétés
        private int idmotif;
        private string libelle;
        
        /// <summary>
        /// Retourne idmotif
        /// </summary>
        public int Idmotif { get => idmotif; }
        /// <summary>
        /// Retourne libelle
        /// </summary>
        public string Libelle { get => libelle; }

        /// <summary>
        /// Constructeur : valorise les propriétés
        /// </summary>
        /// <param name="idmotif"></param>
        /// <param name="libelle"></param>
        public Motif(int idmotif, string libelle)
        {
            this.idmotif = idmotif;
            this.libelle = libelle;
        }
    }