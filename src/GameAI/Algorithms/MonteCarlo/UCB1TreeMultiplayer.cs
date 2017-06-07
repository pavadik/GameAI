﻿using System.Collections.Generic;
using SystemExtensions.Copying;
using GameAI.GameInterfaces;

namespace GameAI.Algorithms.MonteCarlo
{
    public static class UCB1TreeMultiplayer<TGame, TMove, TPlayer>
        where TGame : UCB1TreeMultiplayer<TGame, TMove, TPlayer>.IGame
    {
        public interface IGame :
            ICopyable<TGame>,
            IInt64Hash,
            IGameOver,
            ICurrentPlayer<TPlayer>,
            ITransition<Transition>
        {
            /// <summary>
            /// Perform any random move. To optimize this method,
            /// omit the use and update of the hash value.
            /// </summary>
            void DoRandomMove();
            /// <summary>
            /// Returns an array, indexed by numeric player representations,
            /// that specifies, for that player, a win (+1), loss (-1), or tie (0).
            /// </summary>
            int[] GetOutcome();
            List<Transition> GetLegalTransitions();
        }

        public class Transition
        {
            public TMove move;
            public long hash;

            public Transition(TMove move, long hash)
            {
                this.move = move;
                this.hash = hash;
            }

            public override string ToString()
            {
                return "Move: " + move.ToString() + ". Hash: " + hash.ToString();
            }
        }
        
    }
}
