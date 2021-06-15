<template>
    <div class="content">
        <div class="content-area">
            <div class="top-content">
                <div class="content-title">Nhân viên</div>
                <div class="button-field">
                    <button class="btn" style="font-family:inherit;" @click="btnAddOnClick()">Thêm mới nhân viên</button>
                </div>
            </div>
            <div class="main-content">
                <div class="sticky">
                    <div class="search-field">
                        <div style="padding-right: 16px;">
                            <div class="content-input-list">
                                <div class="ms-input ms-editor is-label-placeholder input-search" data-v-61e45b06="">
                                    <div>
                                        <div class="ms-component ms-con-input-label ms-input style-label">
                                            <span>
                                                <div class="ms-con-input">
                                                    <input mstextfield="" placeholder="Tìm theo mã, tên nhân viên" type="text" class="ms-inputx ms-input--input normal hasIcon icon-after-input placehoder ms-input-normal"
                                                    v-model="message" @keyup="searchData(message)">
                                                    <div iconpack="feather" icon="mi-search" class="icon-inputx notranslate ms-input--icon icon-after icon-no-border mi-search mi mi-16"></div>
                                                </div>
                                            </span>
                                            <span></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="filter-conditions"></div>
                        </div>
                        <div style="padding-top: 5px; padding">
                            <div class="refresh-button list-button">
                                <div class="con-ms-tooltip">
                                    <div class="msTooltipParent"></div>
                                    <div class="tooltip-content">
                                        <div class="mi mi-24 mi-refresh"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="grid">
                    <table id="tblListCustomer" class="table" width="100%">
                        <thead>
                            <tr>
                                <th><input type="checkbox" name="" id="" class="none"/></th>
                                <th style="text-align: left">Mã nhân viên</th>
                                <th style="text-align: left">Tên nhân viên</th>
                                <th style="text-align: left">Giới tính</th>
                                <th>Ngày sinh</th>
                                <th style="text-align: left">Số CMND</th>
                                <th style="text-align: left">Chức danh</th>
                                <th style="text-align: left">Tên đơn vị</th>
                                <th style="text-align: left">Số tài khoản</th>
                                <th style="text-align: left">Tên ngân hàng</th>
                                <th style="text-align: left">Chi nhánh Tk ngân hàng</th>
                                <th>Chức năng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr
                                v-for="employee in employees"
                                :key="employee.employeeId"
                                @dblclick="rowOnDblClick(employee.employeeId)"
                            >
                                <td><input type="checkbox" name="" id="" /></td>
                                <td>{{ employee.employeeCode }}</td>
                                <td>{{ employee.fullName }}</td>
                                <td>{{ genderName(employee.gender) }}</td>
                                <td>{{ formatDate(employee.dateOfBirth) }}</td>
                                <td>{{ employee.identityNumber }}</td>
                                <td>{{ employee.jobTitle }}</td>
                                <td>{{ departmentName(employee.departmentId) }}</td>
                                <td>{{ employee.bankAccount }}</td>
                                <td>{{ employee.bankName }}</td>
                                <td>{{ employee.bankBranch }}</td>
                                <td>
                                    <Option 
                                    @showDeleteDialog="showDeleteDialog(employee.employeeId,employee.fullName)"
                                    @showEmployeeDetail="showEmployeeDetail(employee.employeeId)"
                                />
                                <EmployeeDelete
                                    :employeeId="employeeId"
                                    :employeeName="employeeName"
                                    :isShow="isShowDialogDelete"
                                    @hideDialog="hideDialog"
                                />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <EmployeeDetail
                :isHide="isHideDialogDetail"
                :employeeId="employeeId"
                :formMode="detailFormMode"
                @btnAddOnClick="btnAddOnClick"
            />
        </div>
        
    </div>
</template>

<script>
    import EmployeeDetail from "../layout/EmployeeDetail.vue";
    import Option from './Option.vue';
    import EmployeeDelete from "./EmployeeDelete.vue";
    import axios from "axios";
    export default {
        components: {
            EmployeeDetail,
            Option,
            EmployeeDelete
        },
        created() {
            this.getData();
        },
        methods: {
            getData() {
                this.data = axios
                .get("https://localhost:44327/api/v1/Employees")
                .then((response) => {
                    this.employees = response.data;
                    this.filterEmployee = response.data;
                });
            },
            btnAddOnClick(isShowDialog) {
                if (isShowDialog == true) {
                    this.detailFormMode = null;
                    this.employeeId = null;
                    this.isHideDialogDetail = true;
                } else {
                    this.detailFormMode = "add";
                    this.isHideDialogDetail = false;
                }
            },
            formatDate(date) {
                if (date==null) return null;
                var newDate = new Date(date);
                var dateString = newDate.getDate();
                var monthString = newDate.getMonth() + 1;
                var year = newDate.getFullYear();
                var s = "";
                var t = "";
                if (dateString < 10) {
                    s = "0" + dateString.toString();
                } else {
                    s = dateString.toString();
                }
                if (monthString < 10) {
                    t = "0" + monthString.toString();
                } else {
                    t = monthString.toString();
                }
                return s + "/" + t + "/" + year;
            },
            genderName(gender) {
                if (gender == 0) return "Nam";
                if (gender == 1) return "Nữ";
                if (gender == 2) return "Không xác định"; 
            },
            departmentName(departmentId) {
                if (departmentId == "35e773ea-5d44-2dda-26a8-6d513e380bde") return "Phòng kế toán";
                if (departmentId == "3f8e6896-4c7d-15f5-a018-75d8bd200d7c") return "Phòng công nghệ";
                if (departmentId == "45ac3d26-18f2-18a9-3031-644313fbb055") return "Phòng Marketing";
                if (departmentId == "78aafe4a-67a7-2076-3bf3-eb0223d0a4f7") return "Phòng quản lý";
                if (departmentId == "7c4f14d8-66fb-14ae-198f-6354f958f4c0") return "Phòng nhân sự";
            },
            rowOnDblClick(employeeId) {
                this.employeeId = employeeId;
                this.isHideDialogDetail = false;
                this.detailFormMode = "update";
            },
            showDeleteDialog(employeeId, employeeName){
                this.employeeId = employeeId;
                this.employeeName = employeeName;
                this.isShowDialogDelete = true;
            },
            showEmployeeDetail(employeeId){
                this.employeeId = employeeId;
                this.isHideDialogDetail = false;
                this.detailFormMode = "update";
            },
            //ẩn dialog thêm nhân viên và dialog xóa nhân viên
            hideDialog(){
                this.isShowDialogEmployee = false;
                this.isShowDialogDelete = false;
                this.getData();
            },
            searchData(search_input){
                console.log(search_input);
                    if(search_input == "") {
                        this.getData();
                    }
            
                else{
                    axios.get("https://localhost:44327/api/v1/Employees/Search?searchField=" + search_input)
                    .then(res => {
                    // console.log(res);
                        this.employees = res.data;
                })
                .catch((res) =>{
                    console.log(res);
                });
            }       
        }
        },
        data() {
            return {
                isHideDialogDetail: true,
                employeeId: null,
                employeeName: null,
                employeeCode: null,
                detailFormMode: null,
                isHideDialogDelete: true,
                employees: [],
                isShowDialogDelete: false,

                message: null,
                filterEmployee: [],
            }
        }
    };
</script>

<style scoped>
    @import url(content.css);
    .content {
        position: absolute;
        top: 48px;
        left: 178px;
        height: calc(100vh - 48px);
        width: calc(100% - 178px);
    }

        .content .content-area {
            padding-left: 20px;
            padding-right: 30px;
        }

    .top-content {
        padding-top: 22px;
        padding-bottom: 16px;
        position: relative;
        display: flex;
        justify-content: space-between;
    }

    .content-title {
        font-size: 24px;
        font-weight: 700;
        color: #111;
        font-family: 'notosans-bold.3ede5aff';
    }

    .button-field {
        font-size: 13px;
        font-family: notosans-regular.2cb88a13;
    }

    .main-content {
        position: absolute;
        left: 20px;
        top: 74px;
        background-color: #ffffff;
        width: calc(100% - 50px);
        height: calc(100% - 90px);
    }

    .sticky {
        position: sticky;
    }

    .search-field {
        position: absolute;
        right: 0;
        padding-top: 16px;
        padding-right: 16px;
        padding-bottom: 10px;
        font-family: inherit;
        display: flex;
    }

    .grid-model-control {
        width: calc(100% - 32px);
        max-width: calc(100% - 32px);
        overflow-y: auto;
        overflow-x: auto;
        position: absolute;
        height: calc(100% - 58px);
        top: 58px;
        left: 16px;
        /*padding-left: 16px;
        padding-right: 16px;*/
    }

    .grid-list-data .grid-button-list .ultility-buttons .list-button {
        padding: 0 6px;
    }

    .justify-center {
        justify-content: center !important;
    }

    label .ms-component .con-ms-checkbox .justify-center {
        max-width: 18px;
        max-height: 18px;
        padding-left: 0px;
        padding-right: 0px;
    }
    
    .fixed-input {
        margin: 0 0 0 0;
        border: none;
        padding: 0 0 0 0;
    }

    .fixed-width-39 {
        width: 39px;
    }
    .none{
        left: -10px;
    }
    .ms-input-normal{
        outline: none;
    }
    @font-face {
        font-family: 'notosans-bold.3ede5aff';
        src: url('../../assets/fonts/notosans-bold.3ede5aff.woff2') format('woff2');
    }

    @font-face {
        font-family: 'notosans-regular.2cb88a13';
        src: url('../../assets/fonts/notosans-regular.2cb88a13.woff2') format('woff2');
    }
</style>