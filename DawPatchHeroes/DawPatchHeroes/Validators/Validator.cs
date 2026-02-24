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
            throw new ArgumentException("Error ⚠️: All Heroes need to have a name", nameof(heroe.Name));
        }
        if (heroe.Hp<=0) {
            throw new ArgumentException("Error ⚠️: Heroe's hp can't be lower than 0", nameof(heroe.Hp));
        }
        if (heroe.Lvl<0) {
            throw new ArgumentException("Error ⚠️: Heroe's lvl can't be lower than 0 ", nameof(heroe.Lvl));
        }
        if (heroe.Exp<0) 
        {
            throw new ArgumentException("Error ⚠️:Heroe's Experience can't be negative", nameof(heroe.Exp));
        }
        if (heroe.PowerLvl<0) 
        {
            throw new ArgumentException("Error ⚠️: Heroe's power can't be negative", nameof(heroe.PowerLvl));
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
            throw new ArgumentException("Error ⚠️: All missions MUST have a name", nameof(mission.Name));
        }
        if (mission.Difficulty<=0|| mission.Difficulty>10) {
            throw new ArgumentException("Error ⚠️: The difficulty of a mission MUST be between 1 and 10 only", nameof(mission.Difficulty));
        }
        if (mission.Status!= MisionStatus.Complete || mission.Status!= MisionStatus.Ongoing) {
            throw new ArgumentException("Error ⚠️: The mission can only be Ongoing or complete", nameof(mission.Status));
        }
        if (mission.Team.Count== 0) 
        {
            throw new ArgumentException("Error ⚠️: All missions need atleast 1 heroe in the team ");
        }

        if (mission.CollabRequired && mission.Team.Count <= 1)
        {
            throw new ArgumentException("Error ⚠️: This is a special mission who needs more than 1 heroe to start");
        }
        return mission;
    }
}