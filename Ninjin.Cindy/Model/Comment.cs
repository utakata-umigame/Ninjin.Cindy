﻿using System;

namespace Ninjin.Cindy.Model
{
    public class Comment:CindyModel
    {
        public Comment()
        {

        }
        public override CindyModel FromJSON(dynamic obj)
        {
            try
            {
                return new Comment()
                {
                    Id = obj.id,
                    Content = obj.content,
                    Mondai = CindyModel.FromJSON(obj.mondai_id, ModelType.Mondai)
                };
            }
            catch
            {
                throw new ArgumentException("Invalid type");
            }
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public Mondai Mondai { get; set; }
        public User Sender { get; set; }
        public override string ToString()
        {
            return string.Format("{0}:{1}",Id,Content);
        }
    }
}
