﻿namespace Chitalka_v3.Models
{
    public class Books
    {
        public int id
        {
            set;
            get;
        }
        public string bookInside
        {
            set;
            get;
        }
        public string bookName
        {
            set;
            get;
        }
        public string descriprionBook
        {
            set;
            get;
        }

        //inp поля чисто служебный бдсм
        public string inpImage { get; set; }
        public string inpAuthor { get; set; }
        public string inpCentuary { get; set; }
        public string inpCountry { get; set; }
        public string inpGenre { get; set; }

        public virtual Image Image
        {
            set;
            get;
        }
        
        public virtual Author Author { get; set; }

        public virtual Centuary Centuary { get; set; }

        public virtual Country Country { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
