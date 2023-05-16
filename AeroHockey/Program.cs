using AeroHockey.Core;
using AeroHockey.Core.Types;

var @params = new GameLaunchParams ();

var game = new Game(@params);
game.Run ();