namespace nisab.Desktop.Nouveau_dossier.modele
{
    public class modele
    {
        
    }
}

namespace mediatek86.modele
{
    /// <summary>
    /// création absence
    /// </summary>
    public class Absence
    {
        // declaration des propriétés
        private int idpersonnel;
        private string nom;
        private string prenom;
        private DateTime datedebut;
        private DateTime datefin;
        private int idmotif;
        private string motif;

        /// <summary>
        /// retour idpersonnel
        /// </summary>
        public int Idpersonnel { get => idpersonnel; }
        /// <summary>
        /// retour nom
        /// </summary>
        public string Nom { get => nom; }
        /// <summary>
        /// retour prenom
        /// </summary>
        public string Prenom { get => prenom; }
        /// <summary>
        /// retour datedebut
        /// </summary>
        public DateTime Date_de_debut { get => datedebut; }
        /// <summary>
        /// retour datefin
        /// </summary>
        public DateTime Date_de_fin { get => datefin; }
        /// <summary>
        /// retourne idmotif
        /// </summary>
        public int Idmotif { get => idmotif; }
        /// <summary>
        /// retourne motif
        /// </summary>
        public string Motif { get => motif; }

    
        /// <param name="idpersonnel"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="datedebut"></param>
        /// <param name="datefin"></param>
        /// <param name="idmotif"></param>
        /// <param name="motif"></param>
        public Absence(int idpersonnel, string nom, string prenom, DateTime datedebut, DateTime datefin, int idmotif, string motif)
        {
            this.idpersonnel = idpersonnel;
            this.nom = nom;
            this.prenom = prenom;
            this.datedebut = datedebut;
            this.datefin = datefin;
            this.idmotif = idmotif;
            this.motif = motif;
        }
    }
}