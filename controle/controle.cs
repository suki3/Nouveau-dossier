namespace nisab.Desktop.Nouveau_dossier.controle
{
}   


namespace mediatek86.controle {

}



public class controle {
    ///< summary >
    /// instance se connecter
    ///< /summary >
}
 private frmSeConnecter seConnecter;

///< summary >
    /// instance liste personnel
    ///< /summary >
    to (listePersonnel);
     /// <summary>
        /// instance de frmModificationPersonnel
        /// </summary>
        private frmModificationPersonnel frmModificationPersonnel;

        /// <summary>
        /// instance de frmModificationAbsence
        /// </summary>
        private frmModificationAbsence frmModificationAbsence;

        /// <summary>
        /// instance de frmGererAbsence
        /// </summary>
        private frmGererAbsence frmGererAbsence;

        /// <summary>
        /// Permet de sauvegarder le personnel séléctionné auparavant
        /// </summary>
        private Personnel savePersonnel;

        /// <summary>
        /// Ouverture de la fenêtre
        /// </summary>
        public Controle()
        {
            frmSeConnecter = new frmSeConnecter(this);
            frmSeConnecter.ShowDialog();
        }

        /// <summary>
        /// Demande la vérification de l'authentification
        /// Si correct, alors ouvre la fenêtre principale
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Boolean ControleAuthentification(string login, string pwd)
        {
            if (AccesDonnees.ControleAuthentification(login, pwd))
            {
                frmSeConnecter.Hide();
                frmListePersonnel = new frmListePersonnel(this);
                frmListePersonnel.ShowDialog();
                return true;
            }
            else
            {
                return false;
            }
        }
         /// <summary>
        ///  accéder aux absences d'un personnel
        /// </summary>
        public void DemGererAbsence()
        {
            Personnel personnel = (Personnel)frmListePersonnel.bdgPersonnel.List[frmListePersonnel.bdgPersonnel.Position];
            savePersonnel = personnel;
            frmGererAbsence = new frmGererAbsence(this);
            frmGererAbsence.RemplirListeAbsence(personnel);
            frmGererAbsence.SetNom(personnel.Nom);
            frmGererAbsence.SetPrenom(personnel.Prenom);
            frmGererAbsence.SetIdPersonnel(personnel.Idpersonnel);
            Console.WriteLine("Nom :" + personnel.Nom);
            Console.WriteLine("Prenom :" + personnel.Prenom);
            frmGererAbsence.ShowDialog();

        }

        /// <summary>
        /// ajout d'un personnel
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        public void AddPersonnel(string nom, string prenom, string tel, string mail)
        {
            Service service = (Service)frmListePersonnel.bdgService.List[frmListePersonnel.bdgService.Position];
            int idpersonnel = 0;
            Personnel personnel = new Personnel(idpersonnel, nom, prenom, tel, mail, service.Idservice, service.Nom);
            AccesDonnees.AddPersonnel(personnel);
        }
         /// <summary>
        /// supprimer un personnel
        /// </summary>
        public void DelPersonnel()
        {
            Personnel personnel = (Personnel)frmListePersonnel.bdgPersonnel.List[frmListePersonnel.bdgPersonnel.Position];
            if (MessageBox.Show(" Supprimer ce personnel  " + personnel.Nom + " " + personnel.Prenom + " ?", "Suppression réussie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AccesDonnees.DelAllAbsence(personnel);
                AccesDonnees.DelPersonnel(personnel);
            }
        }
        /// <summary>
        ///  modifier un personnel
        /// </summary>
        public void DemUpdatePersonnel()
        {
            
           
            frmModificationPersonnel = new frmModificationPersonnel(this);
            Personnel personnel = (Personnel)frmListePersonnel.bdgPersonnel.List[frmListePersonnel.bdgPersonnel.Position];
            frmModificationPersonnel.SetIdPersonnel(personnel.Idpersonnel);
            frmModificationPersonnel.SetNom(personnel.Nom);
            frmModificationPersonnel.SetPrenom(personnel.Prenom);
            frmModificationPersonnel.SetTel(personnel.Tel);
            frmModificationPersonnel.SetMail(personnel.Mail);
            frmModificationPersonnel.SetService(personnel.Service);
         
        }
   /// <summary>
        ///  annuler la modification d'une absence
        /// </summary>
        public void AnnulerUpdateAbsence()
        {
            
            frmGererAbsence = new frmGererAbsence(this);
            frmGererAbsence.RemplirListeAbsence(savePersonnel);
            frmGererAbsence.SetNom(savePersonnel.Nom);
            frmGererAbsence.SetPrenom(savePersonnel.Prenom);
            frmGererAbsence.SetIdPersonnel(savePersonnel.Idpersonnel);
            Console.WriteLine("Nom :" + savePersonnel.Nom);
            Console.WriteLine("Prenom :" + savePersonnel.Prenom);
          
        }


        /// <summary>
        /// retour à la liste des personnels
        /// </summary>
        public void RetourListePerso()
        {
            
            frmListePersonnel = new frmListePersonnel(this);
            
        }

        /// <summary>
        /// enregistrer les modifications
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        public void SaveUpdatePersonnel(string nom, string prenom, string tel, string mail)
        {
            Service service = (Service)frmModificationPersonnel.bdgService.List[frmModificationPersonnel.bdgService.Position];
            Personnel personnel = new Personnel(frmModificationPersonnel.GetIdPersonnel(), nom, prenom, tel, mail, service.Idservice, service.Nom);
            AccesDonnees.UpdatePersonnel(personnel);
            frmModificationPersonnel.Hide();
            frmListePersonnel = new frmListePersonnel(this);
            frmListePersonnel.ShowDialog();
        }

        /// <summary>
        /// ajouter une absence
        /// </summary>
        /// <param name="idpersonnel"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="datedebut"></param>
        /// <param name="datefin"></param>
        public void AddAbsence(int idpersonnel, string nom, string prenom, DateTime datedebut, DateTime datefin)
        {
            Console.WriteLine(frmGererAbsence.GetIdPersonnel());
            Motif motif = (Motif)frmGererAbsence.bdgMotif.List[frmGererAbsence.bdgMotif.Position];
            Personnel personnel = new Personnel(frmGererAbsence.GetIdPersonnel(), null, null, null, null, 0, null);
            Absence absence = new Absence(idpersonnel, nom, prenom, datedebut, datefin, motif.Idmotif, motif.Libelle);
            AccesDonnees.AddAbsence(absence);
            frmGererAbsence.RemplirListeAbsence(personnel);
        }

        /// <summary>
        /// supprimer une absence
        /// </summary>
        public void DelAbsence()
        {
            Absence absence = (Absence)frmGererAbsence.bdgAbsence.List[frmGererAbsence.bdgAbsence.Position];
            Personnel personnel = new Personnel(frmGererAbsence.GetIdPersonnel(), null, null, null, null, 0, null);
            if (MessageBox.Show(" Supprimer l'absence de " + personnel.Nom + " " + personnel.Prenom + " ?", "Suppression réussie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AccesDonnees.DelAbsence(absence);
                frmGererAbsence.RemplirListeAbsence(personnel);
            } 
        }

        /// <summary>
        ///  modifiers une absence
        /// </summary>
        /// <param name="datedebut"></param>
        /// <param name="datefin"></param>
        public void SaveUpdateAbsence(DateTime datedebut, DateTime datefin)
        {
            frmModificationAbsence frm = frmModificationAbsence;
            Motif motif = (Motif)frm.bdgMotif.List[frm.bdgMotif.Position];
            Absence absence = new Absence(frm.GetIdPersonnel(), frm.GetNom(), frm.GetPrenom(), frm.GetDateDebut(), frm.GetDateFin(), motif.Idmotif, motif.Libelle);
            AccesDonnees.UpdateAbsence(absence, datedebut, datefin);
            frmGererAbsence = new frmGererAbsence(this);
            Personnel personnel = new Personnel(frm.GetIdPersonnel(), frm.GetNom(), frm.GetPrenom(), null, null, 0, null);
            frmGererAbsence.RemplirListeAbsence(personnel);
            frmGererAbsence.SetNom(frmModificationAbsence.GetNom());
            frmGererAbsence.SetPrenom(frmModificationAbsence.GetPrenom());
           
        }
    

