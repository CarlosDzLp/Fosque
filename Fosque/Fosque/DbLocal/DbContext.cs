using System;
using Fosque.Dependency;
using SQLite;
using Xamarin.Forms;
using Fosque.Models;
using System.Diagnostics;

namespace Fosque.DbLocal
{
    public class DbContext
    {
        #region Constructor
        private readonly SQLiteConnection connection;
        public DbContext()
        {
            try
            {
                var dbPath = DependencyService.Get<IFilePath>().GetPath();
                connection = new SQLiteConnection(dbPath, true);
                connection.CreateTable<UsuarioModel>();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        #endregion

        #region Usuarios
        public void Insertusuario(UsuarioModel usuario)
        {
            try
            {
                connection.Insert(usuario);
            }
            catch(SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void DeleteUsuario()
        {
            try
            {
                connection.DeleteAll<UsuarioModel>();
            }
            catch(SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public UsuarioModel GetUsuario()
        {
            try
            {
                var result = connection.Table<UsuarioModel>().FirstOrDefault();
                return result;
            }
            catch(SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
