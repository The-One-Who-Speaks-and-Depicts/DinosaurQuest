using System.Collections.Generic;
using DinosaurQuest.Creatures;
using DinosaurQuest.Stages;
using DinosaurQuest.Landscapes;
using System.Text;
using System.Linq;
using System.Reflection;

namespace DinosaurQuest.Territories
{
    public class Tile : ITile
    {
        public Character character {get; private set;}
        public List<ICreature> creatures {get; private set;}


        public ILevel currentLevel {get; set;}

        public int X { get; private set; }
        public int Y { get; private set; }
        public List <ITerritory> connectedTerritories {get; private set;}

        public Landscape landscape { get; private set; }


        public void SetX(int previousX, int step)
        {
            X = previousX + step;
        }

        public void SetY(int previousY, int step)
        {
            Y = previousY + step;
        }

        public void PlaceCharacter(Character _character)
        {
            character = _character;
        }

        public bool isAccessible
        {
            get
            {
                if (X > currentLevel.X_length || X < 1 || Y > currentLevel.Y_length || Y < 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Tile(ILevel _currentLevel, int _X, int _Y, Landscape _landscape)
        {
            currentLevel = _currentLevel;
            X = _X;
            Y = _Y;
            connectedTerritories = new List<ITerritory>();
            creatures = new List<ICreature>();
            landscape = _landscape;
        }

        public Tile()
        {

        }

        public override string ToString() {
            var finalDesc = new StringBuilder();
            finalDesc.Append($"{character.name}");
            finalDesc.Append($" is in tile({X}, {Y}).");
            if (creatures.Count > 0)
            {
                finalDesc.Append("The creatures here are: ");
                finalDesc.AppendJoin(", ", creatures);
                finalDesc.Append(".");
            }
            if (connectedTerritories.Count > 0)
            {
                finalDesc.Append("The connected territories are: ");
                var terrs = new List<string>();
                connectedTerritories.ForEach(t =>
                {
                    if (t.GetType().GetInterfaces().Contains(typeof(ITile)))
                    {
                        var fieldX = t.GetType().GetField("X", BindingFlags.Instance | BindingFlags.NonPublic);
                        var fieldY = t.GetType().GetField("Y", BindingFlags.Instance | BindingFlags.NonPublic);
                        var valueX = fieldX.GetValue(t);
                        var valueY = fieldY.GetValue(t);
                        terrs.Add($"Tile ({valueX}, {valueY})");
                    }
                    if (t.GetType().GetInterfaces().Contains(typeof(IHiddenTerritory)))
                    {
                        if (t.isAccessible)
                        {
                            terrs.Add($"accessible new territory");
                        }
                        else
                        {
                            terrs.Add("new territory one does not see yet");
                        }
                    }

                });
                finalDesc.AppendJoin(", ", terrs);
                finalDesc.Append(".");
            }
			if (this.GetType() == typeof(Tile))
			{
				var thisTile = (Tile) this;
                finalDesc.Append(thisTile.landscape.ToString());
            }
            return finalDesc.ToString();
        }
    }
}
