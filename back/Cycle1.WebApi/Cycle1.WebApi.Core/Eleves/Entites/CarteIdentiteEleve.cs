﻿using A3.Lea.Cycle1.WebApi.Core.Commun;

namespace A3.Lea.Cycle1.WebApi.Core.Eleves.Entites
{
    public class CarteIdentiteEleve
    {
        public int Id { get; }

        public string Nom { get; }

        public string Prenom { get; }

        public object? Photo { get; }

        public Sexe Sexe { get; }

        public Niveau Niveau { get; }

        public CarteIdentiteEleve(int id, string nom, string prenom, Sexe sexe, Niveau niveau, object? photo)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Sexe = sexe;
            this.Niveau = niveau;
            this.Photo = photo;
        }
    }
}
