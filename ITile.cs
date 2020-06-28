using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialGame
{
    public interface ITile
    {
        Character character { get; set; }

        ILandscape landscape { get; set; }

        List<ICreature> creaturesOnTile { get; set; }
        
        ILandscape SetLandscape(Level level);

        List<ICreature> GenerateCreatures(Level level);
    }
}
