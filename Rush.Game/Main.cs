﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rush.Maps;
using Rush.World;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Rush
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Main : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        Universe _universe;
        public static ConcurrentBag<Thing> Things;
        public static SpriteFont defaultSystemFont;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Assets";
            Things = new ConcurrentBag<Thing>();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            defaultSystemFont = Content.Load<SpriteFont>(@"Fonts\Segoe");
            _universe = new Universe();
            _universe.LoadMap<TestMap>(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);

            foreach (var t in Things)
                t.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Yellow);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);

            base.Draw(gameTime);

            foreach (var t in Things)
                t.Draw(_graphics, _spriteBatch, gameTime);

            _spriteBatch.DrawString(defaultSystemFont, gameTime.TotalGameTime.ToString(), new Vector2(5, 5), Color.Pink);

            _spriteBatch.End();
        }
    }
}