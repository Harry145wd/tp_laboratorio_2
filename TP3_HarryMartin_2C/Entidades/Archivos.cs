using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public static class Archivos
    {
        #region Binaries
        /// <summary>
        /// Guarda el objeto en el archivo binario especificados por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <returns>true si se pudo guardar</returns>
        public static bool GuardarBin<T>(string path, T item)
        {
            bool ret = false;
            Stream fs = new FileStream(path, FileMode.Create);
            if (fs != null)
            {
                BinaryFormatter ser = new BinaryFormatter();
                ser.Serialize(fs, item);
                fs.Close();
                ret = true;
            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo BIN");
            }
            return ret;
        }
        /// <summary>
        /// Lee y devuelve el objeto del archivo binario especificado por parametro 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>El objeto leido</returns>
        public static T LeerBin<T>(string path)
        {
            T item = default;
            Stream fs = new FileStream(path, FileMode.Open);
            if (fs != null)
            {
                BinaryFormatter ser = new BinaryFormatter();
                item = (T)ser.Deserialize(fs);
                fs.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo BIN");
            }
            return item;
        }

        #endregion

        #region Text
        /// <summary>
        /// Guarda el string en el archivo de texto especificados por parametro
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns>true si se pudo guardar</returns>
        public static bool GuardarTxt(string path, string data)
        {
            bool ret = false;
            StreamWriter writer = new StreamWriter(path);
            if (writer != null)
            {
                writer.WriteLine(data);
                writer.Close();
                ret = true;
            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo TXT");
            }
            return ret;
        }
        /// <summary>
        /// Lee y devuelve el string del archivo de texto especificado por parametro
        /// </summary>
        /// <param name="path"></param>
        /// <returns>El string leido</returns>
        public static string LeerTxt(string path)
        {
            string ret = null;
            StreamReader reader = new StreamReader(path);
            if (reader != null)
            {
                ret = reader.ReadLine();
                reader.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo TXT");
            }
            return ret;
        }
        #endregion

        #region XML
        /// <summary>
        /// Guarda el objeto en el archivo XML especificados por parametro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="item"></param>
        /// <returns>true si se pudo guardar</returns>
        public static bool GuardarXML<T>(string path, T item)
        {
            bool ret = false;
            XmlSerializer serializer;
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            if (writer!= null)
            {
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, item);
                writer.Close();
                ret = true;

            }
            else
            {
                throw new FileNotFoundException("No se pudo crear el archivo XML");
            }
            return ret;

        }
        /// <summary>
        /// Lee y devuelve el objeto del archivo XML especificado por parametro 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>El objeto leido</returns>
        public static T LeerXML<T>(string path)
        {
            T item = default;
            XmlTextReader reader = new XmlTextReader(path);
            XmlSerializer serializer;
            if (reader != null)
            {
                serializer = new XmlSerializer(typeof(T));
                item = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            else
            {
                throw new FileNotFoundException("No se pudo leer el archivo XML");
            }
            return item;
        }
        #endregion
    }
}
