namespace LinesLib
{
    public class LineSigment
    {
        public int Start { get; set; }
        public int End { get; set; }

        public LineSigment(int start, int end)
        {
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public bool Contains(int punkt)
        { 
            if (punkt >= Start && punkt <= End)
            { 
                return true;
            } 
            return false; 
        }
        public bool Contains(LineSigment lineSegment)
        
        {
            if (lineSegment.Start >= Start && lineSegment.End <= End)
            {
                return true; 
            } 
            return false; 
        }

    }
}