using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_Words.Model;
using Demo1_Words.Model.Interface;
using Unity;

namespace Demo1_Words.Factory.Interface
{
    interface ILevelFactory
    {
        Level CreateLevel(string chosenLevel, IUnityContainer unityContainer);
    }
}
