﻿/// <copyright>
///
/// SharpQuakeEvolved changes by optimus-code, 2019
/// 
/// Based on SharpQuake (Quake Rewritten in C# by Yury Kiselev, 2010.)
///
/// Copyright (C) 1996-1997 Id Software, Inc.
///
/// This program is free software; you can redistribute it and/or
/// modify it under the terms of the GNU General Public License
/// as published by the Free Software Foundation; either version 2
/// of the License, or (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
///
/// See the GNU General Public License for more details.
///
/// You should have received a copy of the GNU General Public License
/// along with this program; if not, write to the Free Software
/// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
/// </copyright>

using SharpQuake.Framework;
using System;
using System.Text;

namespace SharpQuake.Rendering.UI.Elements.HUD
{
    public class MPMiniScoreboard : BaseUIElement
    {
        public override Boolean ManualInitialisation
        {
            get
            {
                return true;
            }
        }

        private HudResources _resources;

        public MPMiniScoreboard( Host host ) : base( host )
        {
        }

        public override void Initialise( )
        {
            base.Initialise( );

            _resources = _host.Screen.HudResources;

            HasInitialised = true;
        }

        /// <summary>
        /// Sbar_DeathmatchOverlay
        /// </summary>
        public override void Draw( )
        {
            base.Draw( );

            if ( !IsVisible || !HasInitialised )
                return;

            if ( _host.Screen.vid.width < 512 || _resources.Lines == 0 )
                return;

            _host.Screen.CopyEverithing = true;
            _host.Screen.FullUpdate = 0;

            // scores
            _resources.SortFrags( );

            // draw the text
            var l = _resources._ScoreBoardLines;
            var y = _host.Screen.vid.height - _resources.Lines;
            var numlines = _resources.Lines / 8;
            if ( numlines < 3 )
                return;

            //find us
            Int32 i;
            for ( i = 0; i < _resources._ScoreBoardLines; i++ )
                if ( _resources._FragSort[i] == _host.Client.cl.viewentity - 1 )
                    break;

            if ( i == _resources._ScoreBoardLines ) // we're not there
                i = 0;
            else // figure out start
                i = i - numlines / 2;

            if ( i > _resources._ScoreBoardLines - numlines )
                i = _resources._ScoreBoardLines - numlines;
            if ( i < 0 )
                i = 0;

            var x = 324;
            for ( ; i < _resources._ScoreBoardLines && y < _host.Screen.vid.height - 8; i++ )
            {
                var k = _resources._FragSort[i];
                var s = _host.Client.cl.scores[k];
                if ( String.IsNullOrEmpty( s.name ) )
                    continue;

                // draw background
                var top = s.colors & 0xf0;
                var bottom = ( s.colors & 15 ) << 4;
                top = _resources.ColorForMap( top );
                bottom = _resources.ColorForMap( bottom );

                _host.Video.Device.Graphics.FillUsingPalette( x, y + 1, 40, 3, top );
                _host.Video.Device.Graphics.FillUsingPalette( x, y + 4, 40, 4, bottom );

                // draw number
                var num = s.frags.ToString( ).PadLeft( 3 );
                _host.DrawingContext.DrawCharacter( x + 8, y, num[0] );
                _host.DrawingContext.DrawCharacter( x + 16, y, num[1] );
                _host.DrawingContext.DrawCharacter( x + 24, y, num[2] );

                if ( k == _host.Client.cl.viewentity - 1 )
                {
                    _host.DrawingContext.DrawCharacter( x, y, 16 );
                    _host.DrawingContext.DrawCharacter( x + 32, y, 17 );
                }

                // draw name
                _host.DrawingContext.DrawString( x + 48, y, s.name );

                y += 8;
            }
        }
    }
}
