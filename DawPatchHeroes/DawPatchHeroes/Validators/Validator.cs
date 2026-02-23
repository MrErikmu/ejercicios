using System.Text.RegularExpressions;
using DawPatchHeroes.Models;

namespace DawPatchHeroes.Validators;

public class Validator: IValidator
{
    /// <summary>
    /// Función auxiliar para validar las entradas del menu usando regex
    /// </summary>
    /// <param name="pattern"> Expresion regular con la que comparar la entrada de datos</param>
    /// <param name="entry"> entrada de datos por consola</param>
    /// <returns>Devuelve verdadero o falso si la entrada es correcta o erronea</returns>
    /// <exception cref="NotImplementedException"></exception>
    
    /// <summary>
    /// Validación de los datos del heroe
    /// </summary>
    /// <param name="heroe">Objeto heroe creado por el usuario</param>
    /// <returns>Devuelve el objeto Heroe cuando todos sus datos sean correctos </returns>
    /// <exception cref="ArgumentException"></exception>
    public Heroe ValidateHeroe(Heroe heroe)
    {
        if (string.IsNullOrWhiteSpace(heroe.Name)) {
            throw new ArgumentException("Todos los heroes necesitan un nombre/alias.", nameof(heroe.Name));
        }
        if (heroe.Hp<=0) {
            throw new ArgumentException("La Vida del heroe no puede ser negativa", nameof(heroe.Hp));
        }
        if (heroe.Lvl<0) {
            throw new ArgumentException("El nivel del heroe no puede ser negativo  ", nameof(heroe.Lvl));
        }
        if (heroe.Exp<0) 
        {
            throw new ArgumentException("La experiencia del heroe no  puede ser negativa  ", nameof(heroe.Exp));
        }
        if (heroe.PowerLvl<0) 
        {
            throw new ArgumentException("El poder del heroe no  puede ser negativo ", nameof(heroe.PowerLvl));
        }
        return heroe;
    }
        /// <summary>
        /// Validacion de los datos de la misión
        /// </summary>
        /// <param name="mission"> Objeto Mision creado por el usuario</param>
        /// <returns> Devuelve el objeto mision cuando todos los datos son correctos</returns>
        /// <exception cref="ArgumentException"></exception>
    public Mission ValidateMission(Mission mission)
    {
        if (string.IsNullOrWhiteSpace(mission.Name)) {
            throw new ArgumentException("El Nombre de la mision no puede estar vacio.", nameof(mission.Name));
        }
        if (mission.Difficulty<=0|| mission.Difficulty>10) {
            throw new ArgumentException("La dificultad debe estar comprendida entre 1 y 10", nameof(mission.Difficulty));
        }
        if (mission.Status!= MisionStatus.Complete || mission.Status!= MisionStatus.Ongoing) {
            throw new ArgumentException("La mission solo puede estar completada o en proceso", nameof(mission.Status));
        }
        if (mission.Team.Count== 0) 
        {
            throw new ArgumentException("Se debe asignar al menos un heroe a la mission");
        }
        return mission;
    }
}