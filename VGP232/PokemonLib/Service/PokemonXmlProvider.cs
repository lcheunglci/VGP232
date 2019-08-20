using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using PokemonLib.Models;

namespace PokemonLib.Service
{
    public class PokemonXmlProvider : IDataProvider<Pokemon>
    {
        private readonly XDocument doc;
        private readonly string xmlFilePath;

        public PokemonXmlProvider(string xmlFilePath)
        {
            this.xmlFilePath = xmlFilePath;
            doc = XDocument.Load(xmlFilePath);
        }

        public Pokemon GetById(int id)
        {
            return GetElementById(id)?.FromXElement<Pokemon>();
        }

        public void Edit(Pokemon newEntity)
        {
            var entityById = GetElementById(newEntity.Id);
            entityById.Attribute("Id").Value = newEntity.Id.ToString();
            entityById.Attribute("Name").Value = newEntity.Name;
            entityById.Attribute("HP").Value = newEntity.HP.ToString();
            entityById.Attribute("Attack").Value = newEntity.Attack.ToString();
            entityById.Attribute("Defense").Value = newEntity.Defense.ToString();
            entityById.Attribute("MaxCP").Value = newEntity.MaxCP.ToString();
            entityById.Attribute("MType").Value = newEntity.MType.ToString();
    }

        public void Add(Pokemon entity)
        {
            var element = entity.ToXElement<Pokemon>();
            doc.Root.Add(element);
        }

        public void Remove(int id)
        {
            var entityById = GetElementById(id);
            entityById.Remove();
        }

        public IEnumerable<Pokemon> GetAll()
        {
            return doc.Descendants("Pokemon").Select(element => element.FromXElement<Pokemon>());
        }

        public void SaveChanges()
        {
            doc.Save(xmlFilePath);
        }

        private XElement GetElementById(int id)
        {
            var result = doc.Descendants("Pokemon")
                .SingleOrDefault(element => (int)element.Attribute("Id") == id);
            return result;
        }
    }
}