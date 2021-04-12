using MVVMTools;
using System;
using System.Collections.Generic;
using System.Text;
using WpfAppMVVM.Message;
using WpfAppMVVM.Models;
using WpfAppMVVM.Services;

namespace WpfAppMVVM.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public IMessanger messanger { get; set; }
        public IProductRepository ProductRepository { get; set; }
        private string editorName;
        public string EditorName
        {
            get => editorName;
            set => ChangeProp(out editorName, value);
        }

        private float editorPrice;
        public float EditorPrice
        {
            get => editorPrice;
            set => ChangeProp(out editorPrice, value);
        }

        private int editorCount;
        public int EditorCount
        {
            get => editorCount;
            set => ChangeProp(out editorCount, value);
        }

        private bool editorFavorite;
        public bool EditorFavorite
        {
            get => editorFavorite;
            set => ChangeProp(out editorFavorite, value);
        }

        private DateTime editorDate = DateTime.Now;
        public DateTime EditorDate
        {
            get => editorDate;
            set => ChangeProp(out editorDate, value);
        }

        private Command navBack;
        public Command NavBack => navBack ??= new Command(() => { Clear(); messanger.Send<NavigationMessage>(new NavigationMessage { ViewModelType = typeof(HomeViewModel) }); });

        public DetailViewModel(IMessanger messanger, IProductRepository productRepository)
        {
            this.messanger = messanger;
            this.ProductRepository = productRepository;
            messanger.Subcribe<ProductDetailMessage>(i =>
            {
                var message = i as ProductDetailMessage;
                Product product = ProductRepository.GetProduct(message.NameProduct);
                if (product != null)
                {
                    EditorName = product.Name;
                    EditorPrice = product.Price;
                    EditorCount = product.Count;
                    EditorFavorite = product.Favorite;
                    EditorDate = product.Date;
                }
            });
        }
        private void Clear()
        {
            EditorPrice = 0;
            EditorCount = 0;
            EditorName = string.Empty;
            EditorFavorite = false;
            EditorDate = DateTime.Now;
        }
    }
}
