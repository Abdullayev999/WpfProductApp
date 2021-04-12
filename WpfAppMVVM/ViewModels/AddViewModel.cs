using MVVMTools;
using System;
using System.Collections.Generic;
using System.Text;
using WpfAppMVVM.Message;
using WpfAppMVVM.Models;
using WpfAppMVVM.Services;

namespace WpfAppMVVM.ViewModels
{
    public class AddViewModel : BaseViewModel
    {
        public IProductRepository ProductRepository { get; set; }
        public IMessanger messanger { get; set; }
        private string editorName;
        public string EditorName
        {
            get => editorName;
            set
            {
                ChangeProp(out editorName, value);
                AddProduct.NotifyCanExecuteChanged();
            }
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

        private Command addProduct;
        public Command AddProduct => addProduct ??= new Command(Add, () => !string.IsNullOrWhiteSpace(EditorName));

        private Command navBack;

        public Command NavBack => navBack ??= new Command(()=>{ Clear(); messanger.Send<NavigationMessage>(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });});

        public AddViewModel(IMessanger messanger, IProductRepository productRepository)
        {
            this.messanger = messanger;
            this.ProductRepository = productRepository;
        }

        private void Clear()
        {
            EditorPrice = 0;
            EditorCount = 0;
            EditorName = string.Empty;
            EditorFavorite = false;
            EditorDate = DateTime.Now;
        }
        public void Add()
        {
            ProductRepository.AddProduct(new Product { Name = EditorName, Price = EditorPrice, Count = EditorCount, Favorite = EditorFavorite, Date = EditorDate });
            Clear();
            messanger.Send<NavigationMessage>(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });
        }

    }
}
