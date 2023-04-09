(function () {
    $(function () {

        var _$productTable = $('#ProductTable');
        var _productsService = abp.services.app.products;
        l = abp.localization.getSource('Test');

        //$('.date-picker').datetimepicker({
        //    locale: abp.localization.currentLanguage.name,
        //    format: 'L'
        //});

        var _permissions = {
            create: abp.auth.hasPermission('Pages.Products.Create'),
            edit: abp.auth.hasPermission('Pages.Products.Edit'),
            /*'delete': abp.auth.hasPermission('Pages.FSCEvents.Delete')*/
        };

       



        var dataTable = _$productTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            searching: false,
            ordering: true,
            ajax: function (data, callback, settings) {
                var filter = $('#ProductSearchForm').serializeFormToObject(true);
                filter.maxResultCount = data.length;
                filter.skipCount = data.start;
                abp.ui.setBusy(_$productTable);
                _productsService.getAll(filter).done(function (result) {
                    debugger;
                    callback({
                        recordsTotal: result.totalCount,
                        recordsFiltered: result.totalCount,
                        data: result.items
                    });
                }).always(function () {
                    abp.ui.clearBusy(_$productTable);
                });

            },
         
            buttons: [
                {
                    name: 'refresh',
                    text: '<i class="fas fa-redo-alt"></i>',
                    action: () => _$productTable.draw(false)
                }
            ],
            responsive: {
                details: {
                    type: 'column'
                }
            },
            columnDefs: [
                {
                    width: 120,
                    targets: 3,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    render: (data, type, row, meta) => {
                        debugger
                        return [
                            `   <a   ${_permissions.edit == true ? "style='display:inline'" : "style='display:none'"} class="btn btn-sm btn-primary" href="/Products/CreateOrEdit/${row.product.id}">`,
                            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                            '   </a>',
                            `   <a  class="btn btn-sm bg-danger delete-product" data-product-id="${row.product.id}" >`,
                            `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                            '   </a>',
                        ].join('');
                       
                    }
                },
                {
                    targets: 0,
                    data: "product.name",
                    name: "name"
                },
                {
                    targets: 1,
                    data: "product.description",
                    name: "description",
                    
                },
                {
                    targets: 2,
                    data: "product.price",
                    name: "price",
                    
                },
            ]
        });

        //$('#ProductTable tbody').on('click', 'tr td:not(:last-child)', function () {
        //    //if (_permissions.edit == true) {
        //        var data = dataTable.row(this).data();
        //        window.location = "/Products/CreateOrEdit/" + data.product.id;
        //    //}
        //});

        function getVehicleNotes() {
            dataTable.ajax.reload();
        }

        $(document).on('click', '.delete-product', function () {
            var productId = $(this).attr("data-product-id");

            deleteProduct(productId);
        });

        function deleteProduct(productId) {
            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete')),
                null,
                (isConfirmed) => {
                    if (isConfirmed) {
                        _productsService.delete({
                            id: productId
                        }).done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            dataTable.ajax.reload();
                        });
                    }
                }
            );
        }

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });



        //$('#ExportToExcelButton').click(function () {
        //    _vehicleNotesService
        //        .getVehicleNotesToExcel({
        //            filter: $('#FSCEventTableFilter').val(),
        //            noteFilter: $('#NoteFilterId').val(),
        //            minNoteDateFilter: getDateFilter($('#MinNoteDateFilterId')),
        //            maxNoteDateFilter: getDateFilter($('#MaxNoteDateFilterId')),
        //            vehicleNameFilter: $('#VehicleNameFilterId').val()
        //        })
        //        .done(function (result) {
        //            app.downloadTempFile(result);
        //        });
        //});

        abp.event.on('app.createOrEditVehicleNoteModalSaved', function () {
            getVehicleNotes();
        });

        $('#GetVehicleNotesButton').click(function (e) {
            e.preventDefault();
            getVehicleNotes();
        });

        $(document).keypress(function (e) {
            if (e.which === 13) {
                getVehicleNotes();
            }
        });
    });
})();