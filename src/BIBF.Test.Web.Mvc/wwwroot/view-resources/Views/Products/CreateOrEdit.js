(function () {
    $(function () {
        debugger;
        var _productsService = abp.services.app.products;

        l = abp.localization.getSource('Test');
        var _$productInformationForm = $('form[name=ProductInformationsForm]');
        _$productInformationForm.validate();

        

        function save(successCallback) {
            debugger;
            if (!_$productInformationForm.valid()) {
                return;
            }

            var product = _$productInformationForm.serializeFormToObject();
			
			 abp.ui.setBusy();
            _productsService.createOrEdit(
                product
			 ).done(function () {
                 abp.notify.info(l('SavedSuccessfully'));
                 window.location = "/products";
               
               if(typeof(successCallback)==='function'){
                    successCallback();
               }
			 }).always(function () {
			    abp.ui.clearBusy();
			});
        };
        
        function clearForm(){
            _$productInformationForm[0].reset();
        }
        
        $('#saveBtn').click(function () {
            debugger;
            save(function(){
                window.location="/products";
            });
        });
        
        $('#saveAndNewBtn').click(function(){
            save(function(){
                if (!$('input[name=id]').val()) {//if it is create page
                   clearForm();
                }
            });
        });
    });
})();