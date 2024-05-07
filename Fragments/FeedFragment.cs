using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using DevConnect.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace DevConnect.Fragments
{
    public class FeedFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.feed_layout_frag, container, false);
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            List<PostModel> postlist = Constant.GetPostModels();
            // Assign employeelist to ItemAdapter
            FeedAdapter itemAdapter = new FeedAdapter(postlist);
            // Set the LayoutManager that
            // this RecyclerView will use.
            RecyclerView recyclerView
                = (RecyclerView)view.FindViewById(Resource.Id.recycleView);
            recyclerView.SetLayoutManager(
                new LinearLayoutManager(Context));
            // adapter instance is set to the
            // recyclerview to inflate the items.
            recyclerView.SetAdapter(itemAdapter);
        }
    }
}