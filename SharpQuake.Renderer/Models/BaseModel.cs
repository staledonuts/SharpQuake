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

using System;
using System.Collections.Generic;
using SharpQuake.Framework;
using SharpQuake.Framework.Mathematics;
using SharpQuake.Renderer.Textures;

namespace SharpQuake.Renderer.Models
{
    public class BaseModel : IDisposable
    {
        public BaseDevice Device
        {
            get;
            private set;
        }

        public BaseModelDesc Desc
        {
            get;
            protected set;
        }

        public static Dictionary<String, BaseModel> ModelPool
        {
            get;
            protected set;
        }

        static BaseModel( )
        {
            ModelPool = new Dictionary<String, BaseModel>( );
        }

        public BaseModel( BaseDevice device, BaseModelDesc desc )
        {
            Device = device;
            Desc = desc;
            ModelPool.Add( Desc.Name, this );
        }

        public virtual void Initialise( )
        {
            //throw new NotImplementedException( );
        }

        public virtual void Draw( )
        {
        }

        /// <summary>
        /// R_DrawAliasModel
        /// </summary>
        public virtual void DrawAliasModel( Single shadeLight, Vector3 shadeVector, Single[] shadeDots, Single lightSpotZ, aliashdr_t paliashdr, Double time, Boolean shadows = true, Boolean smoothModels = true, Boolean affineModels = false, Boolean noColours = false, Boolean isEyes = false )
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// GL_DrawAliasShadow
        /// </summary>
        protected virtual void DrawAliasShadow( aliashdr_t paliashdr, Int32 posenum, Single lightSpotZ, Vector3 shadeVector )
        {
            throw new NotImplementedException( );
        }

        /// <summary>
        /// R_SetupAliasFrame
        /// </summary>
        protected virtual void SetupAliasFrame( Single shadeLight, Int32 frame, Double time, aliashdr_t paliashdr, Single[] shadeDots )
        {
            if ( ( frame >= paliashdr.numframes ) || ( frame < 0 ) )
            {
                ConsoleWrapper.Print( "R_AliasSetupFrame: no such frame {0}\n", frame );
                frame = 0;
            }

            var pose = paliashdr.frames[frame].firstpose;
            var numposes = paliashdr.frames[frame].numposes;

            if ( numposes > 1 )
            {
                var interval = paliashdr.frames[frame].interval;
                pose += ( Int32 ) ( time / interval ) % numposes;
            }

            DrawAliasFrame( shadeLight, shadeDots, paliashdr, pose );
        }

        /// <summary>
        /// GL_DrawAliasFrame
        /// </summary>
        protected virtual void DrawAliasFrame( Single shadeLight, Single[] shadeDots, aliashdr_t paliashdr, Int32 posenum )
        {
            throw new NotImplementedException( );
        }

        public virtual void Dispose( )
        {
        }

        public static BaseModel Create( BaseDevice device, String identifier, BaseTexture texture, Boolean isAliasModel )
        {
            if ( ModelPool.ContainsKey( identifier ) )
                return ModelPool[identifier];

            var desc = ( BaseModelDesc ) Activator.CreateInstance( device.ModelDescType );
            desc.Name = identifier;
            desc.IsAliasModel = isAliasModel;
            desc.Texture = texture;

            var model = ( BaseModel ) Activator.CreateInstance( device.ModelType, device, desc );
            model.Initialise( );

            return model;
        }
    }
}
