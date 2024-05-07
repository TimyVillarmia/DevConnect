using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Java.Util.Logging;
using Square.Picasso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace DevConnect.Common
{
    internal class FeedAdapter : RecyclerView.Adapter
    {

        private List<PostModel> _feedList;

        public FeedAdapter(List<PostModel> list)
        {
            this._feedList = list;
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override void OnBindViewHolder(ViewHolder holder, int position)
        {

            Adapter1ViewHolder myHolder = holder as Adapter1ViewHolder;
            PostModel currentModel = _feedList[position];
            myHolder.poster_name.Text = currentModel.poster_name;
            myHolder.poster_handler.Text = currentModel.poster_handler;
            myHolder.post_time.Text = currentModel.post_time;
            myHolder.post_description.Text = currentModel.post_description;
            Picasso
                .Get()
                .Load(currentModel.post_image)
                .Fit()
                .CenterCrop()
                .NoFade()
                .Into(myHolder.post_image);

        }

        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.feed_layout_frag, parent, false);
            return new Adapter1ViewHolder(itemView);
        }

        public override int ItemCount => _feedList.Count;
    }


    public class Adapter1ViewHolder : ViewHolder
    {
        public TextView poster_name;
        public TextView poster_handler;
        public TextView post_time;
        public TextView post_description;
        public ImageView post_image;

        public Adapter1ViewHolder(View itemView) : base(itemView)
        {
            poster_name = (TextView)itemView.FindViewById(Resource.Id.textView_poster_name);
            poster_handler = (TextView)itemView.FindViewById(Resource.Id.textView_poster_handler);
            post_time = (TextView)itemView.FindViewById(Resource.Id.time);
            post_description = (TextView)itemView.FindViewById(Resource.Id.design_bottom_sheet);
            post_image = (ImageView)itemView.FindViewById(Resource.Id.imageView_post_image);


        }
    }
}