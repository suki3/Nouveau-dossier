namespace nisab.Desktop.Nouveau_dossier.config
{
    public class NewBaseType
    {
    }

    public class database
    {
        
    }
}
// connexion a la BDD
// string chaineConnexion
// declaration chaineConnexion, server,user id, password, database
ToString(chaineConnexion) ="server=localhost;port=3306; user id=root; password=''; database=laBD";
MySqlConnection connection = new MySqlConnection(chaineConnexion);
connection.Open();
//éxecuter la requete sur l'objet de connection
string req = "SELECT user id,password from password where password>=''";
MySqlCommand command =new MySqlCommand (req, connection);
// fermeture de la connexion 
Connection.Close();


