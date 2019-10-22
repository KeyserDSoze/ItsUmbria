using System;
using System.Collections.Generic;
using System.Text;

namespace ItsUmbria.Solution
{
    /// <summary>
    /// Classe astratta che mi permette di racchiudere tutte le figure geometriche con un concetto.
    /// Lasciarla vuota non implica di aver sbagliato progettazione, può esser fatto per dare maggior leggibilità
    /// alle classi Triangle, Line, etc.
    /// Il concetto di classe astratta nasce dal fatto che non deve essere istanziata, il suo significato può essere 
    /// rivisto nel mito della caverna di platone https://it.wikipedia.org/wiki/Mito_della_caverna
    /// </summary>
    public abstract class Figure
    {
    }
}
