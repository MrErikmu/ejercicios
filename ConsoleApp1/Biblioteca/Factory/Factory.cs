using ConsoleApp1.Models;
using ConsoleApp1.Models.Lista;
using ConsoleApp1.repository;

namespace ConsoleApp1.Factory;

public static class Factory
{
        public static Lista<Ficha> LLenarLista()
        {
            var bibliotecalista = new Lista<Ficha>();
            Dvd p1 = new Dvd(
                director: "Christopher Nolan", 
                año: 2010, 
                tipo: "Ciencia Ficción", 
                titulo: "Inception"
            )
            {
                Titulo = "Inception"
            };
            Dvd p2 = new Dvd(
                director: "Quentin Tarantino",
                año: 1994,
                tipo: "Crimen", titulo:"Pulp Fiction"
            )
            {
                Titulo = "Pulp Fiction"
            };
            Libro l1 = new Libro("Andrzej Sapkowski", "Alamut","El Último Deseo")
            {
                Titulo = "El Último Deseo"
            };
            Libro l2 = new Libro("Andrzej Sapkowski", "Alamut", "La Torre de la Golondrina")
            {
                Titulo = "La Torre de la Golondrina"
            };
            Revista r1 = new Revista(2023, 12,"El Halcon Peregrino" )
            {
                Titulo = "El Halcon Peregrino"
            };
            Revista r2 = new Revista(2020, 5, "30 Curiosidades de Elden Ring")
            {
                Titulo = "30 Curiosidades de Elden Ring"
            };
            bibliotecalista.AgregarInicio(p1);
            bibliotecalista.AgregarInicio(p2);
            bibliotecalista.AgregarInicio(l1);
            bibliotecalista.AgregarInicio(l2);
            bibliotecalista.AgregarInicio(r1);
            bibliotecalista.AgregarInicio(r2);
            return bibliotecalista;
        }
}