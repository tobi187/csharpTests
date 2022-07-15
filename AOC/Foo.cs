namespace AOC
{
    internal class AdressSplitter
    {
        internal List<string> hyper = new List<string>();
        internal List<string> super = new List<string>();
        private string adress;

        public bool superAbba { get; internal set; }
        public bool hyperAbba { get; internal set; }

        public AdressSplitter(string v)
        {
            this.adress = v;
        }

        internal void DoNext()
        {
            var extracted = adress.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries).First();

            if (adress[0] == '[')
            {
                if (CheckForAbba(extracted))
                    hyperAbba = true;

                adress = adress.Remove(0, extracted.Length + 2);
                hyper.Add(extracted);
            }
            else
            {
                if (CheckForAbba(extracted))
                    superAbba = true;

                adress = adress.Remove(0, extracted.Length);
                super.Add(extracted);
            }
        }

        internal bool CheckForAbba(string seq)
        {
            for (var i = 0; i < seq.Length - 3; i++)
            {
                if (seq[i] == seq[i + 1])
                    continue;

                if (seq[i] == seq[i + 3] && seq[i + 2] == seq[i + 1])
                    return true;
            }
            return false;
        }

        internal void DoAll()
        {
            while (adress.Length > 0)
            {
                DoNext();
            }
        }
    }
}