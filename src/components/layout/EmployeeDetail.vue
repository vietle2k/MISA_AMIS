<template>
  <div>
        <div id="employeeDetail" :class="{ 'dialog-hide': isHide }">
            <div class="model"></div>
                <div class="dialog"  >
                    <div class="dialog-header">
                        <div class="t">
                            <div class="title-dialog">Thông tin nhân viên</div>
                            <div class="b">
                                <input type="checkbox" class="item-1">
                            </div>
                            <div class="text-header">Là khách hàng</div>
                            <div class="b">
                                <input type="checkbox" class="item-1">
                            </div>
                            <div class="text-header">Là nhà cung cấp</div>
                        </div>
                        <div id="exit-button" class="close" @click="btnCloseOnClick()">&#10005;</div>
                    </div>
                    <div class="dialog-content">
                        <div class="content_">
                            <div class="v1">
                                <div class="v1_1"> 
                                    <div class="m_t">
                                        <div class="m">
                                            <label class="ma"> Mã(*)</label>
                                            <label style="font-weight: bold"> Tên(*)</label>                
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="mb" v-model="newEmployeeCode" ref="employeecode"
                                            :class="{ 'red-border': employeeError }">
                                            <input type = "text" class="mc" v-model="newFullName" 
                                            :class="{ 'red-border': nameError }">
                                        </div>
                                    </div>
                                    <div class="dv">
                                        <div class="m">
                                            <label class="ma"> Đơn vị(*)</label>   
                                        </div>
                                        <div class = "t">
                                            <select v-model="newDepartmentId" :class="{ 'red-border': departmentError }">
                                                <option value="35e773ea-5d44-2dda-26a8-6d513e380bde">Phòng kế toán</option>
                                                <option value="3f8e6896-4c7d-15f5-a018-75d8bd200d7c">Phòng công nghệ</option>
                                                <option value="45ac3d26-18f2-18a9-3031-644313fbb055">Phòng Marketing</option>
                                                <option value="78aafe4a-67a7-2076-3bf3-eb0223d0a4f7">Phòng quản lý</option>
                                                <option value="7c4f14d8-66fb-14ae-198f-6354f958f4c0">Phòng nhân sự</option>
                                            </select>                                      
                                        </div>
                                    </div>                                  
                                    <div class="cd">
                                        <div class="m">
                                            <label class="ma"> Chức danh</label>  
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="md" v-model="newJobTitle">                         
                                        </div>
                                    </div>
                                </div>
                                <div class="v1_2">
                                    <div class="ns-gt">
                                        <div class="m">
                                            <label class="ma"> Ngày sinh</label>
                                            <label style="font-weight: bold" class="m_1"> Giới tính</label>                                  
                                        </div>
                                        <div class="t">
                                            <input type = "date" class="mb mb-1" v-model="newDateOfBirth">
                                            <div class="gender">
                                                    <input type="radio" id="contactChoice1"
                                                    name="contact" value="0" checked v-model="newGender">
                                                    <label for="contactChoice1">Nam</label>

                                                    <input type="radio" id="contactChoice2"
                                                    name="contact" value="1" v-model="newGender">
                                                    <label for="contactChoice2">Nữ</label>

                                                    <input type="radio" id="contactChoice3"
                                                    name="contact" value="2" v-model="newGender">
                                                    <label for="contactChoice3">Khác</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="CMND">
                                         <div class="m">
                                            <label class="ma"> Số CMTND</label>
                                            <label style="font-weight: bold" class="m_1"> Ngày cấp</label>                                    
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="me" v-model="newIdentityNumber">
                                            <input type = "date" class="mf" v-model="newIdentityDate">
                                        </div>
                                    </div>
                                    <div class="nc">
                                        <div class="m">
                                            <label class="ma"> Nơi cấp</label>                                    
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="md" v-model="newIdentityPlace">            
                                        </div>
                                    </div>                  
                                </div>                      
                            </div>
                            <div class="v2">
                                <div>
                                    <div class="m">
                                            <label class="ma"> Địa chỉ</label>                          
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="mg" v-model="newAddress">                       
                                        </div>
                                </div>
                                <div class="m_t">
                                        <div class="m">
                                            <label class="ma dt_1"> ĐT di động</label>
                                            <label class ="dt_2" style="font-weight: bold"> ĐT cố định</label>
                                            <label class="email" style="font-weight: bold"> Email</label>                            
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="mt" v-model="newPhone">
                                            <input type = "text" class="mt" v-model="newTelephone">
                                            <input type = "text" class="mt mt-email" v-model="newEmail"
                                            :class="{ 'red-border': emailError }">
                                        </div>
                                    </div>
                                <div class="m_t">
                                        <div class="m">
                                            <label class="ma dt_1 dt_tknh"> Tài Khoản ngân hàng</label>
                                            <label class ="dt_2 dt_3" style="font-weight: bold" > Tên ngân hàng</label>
                                            <label class="email dt_cn" style="font-weight: bold"> Chi nhánh</label>                                     
                                        </div>
                                        <div class="t">
                                            <input type = "text" class="mt" v-model="newBankAccount">
                                            <input type = "text" class="mt" v-model="newBankName">
                                            <input type = "text" class="mt mt-email" v-model="newBankBranch">
                                        </div>
                                    </div>
                            </div>
                        </div>
                        <div class="button-dialog">                        
                            <div>
                                <button class="destroy" @click="btnCloseOnClick()">Hủy</button>
                            </div>
                            <div>
                                <button class="save" @click="checkValidate()">Cất và Thêm</button>
                            </div>
                        </div>  
                    </div>
                </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
  props: {
    isHide: { type: Boolean, default: true },
    employeeId: { type: String, default: null },
    formMode: { type: String, default: null },
  },
  mounted() {
    this.focusInput();
  },
  watch: {
        formMode: function () {
            if (this.formMode == "update") {
                axios
                .get("https://localhost:44327/api/v1/Employees/" + this.employeeId)
                .then((response) => {
                    this.employee = response.data;                 
                    // assign new variable
                        this.newEmployeeCode = this.employee.employeeCode;
                        this.newFullName = this.employee.fullName;
                        //this.newDateOfBirth = this.employee.dateOfBirth;
                        this.newGender = this.employee.gender;
                        this.newDepartmentId = this.employee.departmentId;
                        this.newIdentityNumber = this.employee.identityNumber;
                        //this.newIdentityDate = this.employee.identityDate;
                        this.newIdentityPlace = this.employee.identityPlace;
                        this.newJobTitle = this.employee.jobTitle;
                        this.newAddress = this.employee.address;
                        this.newPhone = this.employee.phone;
                        this.newTelephone = this.employee.telephone;
                        this.newEmail = this.employee.email;
                        this.newBankAccount = this.employee.bankAccount;
                        this.newBankName = this.employee.bankName;
                        this.newBankBranch = this.employee.bankBranch;
                    
                    // DateOfBirth format
                        if (this.employee.dateOfBirth != null) this.newDateOfBirth = this.formatDate(this.employee.dateOfBirth);
    
                    // IdentityDate format
                        if (this.employee.identityDate != null) this.newIdentityDate = this.formatDate(this.employee.identityDate);
                    
                })
                .catch((res) => {
                    console.log(res.status);
                });
            }
            if (this.formMode == 'add') {
                axios
                .get("https://localhost:44327/api/v1/Employees/NewEmployeeCode")
                .then((response) => {
                    this.newEmployeeCode = response.data;
                    
                })
                .catch((res) => {
                    console.log(res.status);
                    alert("Không thể lấy mã nhân viên mới");
                });
            }
            
        },
  },
  methods: {
    btnCloseOnClick() {
        this.newEmployeeCode = null;
        this.newFullName = null;
        this.newDateOfBirth = null;
        this.newGender = null;
        this.newDepartmentId = null;
        this.newIdentityNumber = null;
        this.newIdentityDate = null;
        this.newIdentityPlace = null;
        this.newJobTitle = null;
        this.newAddress = null;
        this.newPhone = null;
        this.newTelephone = null;
        this.newEmail = null;
        this.newBankAccount = null;
        this.newBankName = null;
        this.newBankBranch = null;

        this.validate = true;
        this.nameError = false;
        this.employeeError = false;
        this.departmentError = false;
        this.emailError = false;    

        this.$emit("btnAddOnClick", true);
    },
    formatDate(date) {
            if (date==null) return null;
            var newDate = new Date(date);
            var dateString = newDate.getDate();
            var monthString = newDate.getMonth() + 1;
            var year = newDate.getFullYear();
            var s = '';
            var t = '';
            if (dateString < 10) {
                s = '0' + dateString.toString();
            } else {
                s = dateString.toString();
            }
            if (monthString < 10) {
                t = '0' + monthString.toString();
            } else {
                t = monthString.toString();
            }
            return year + '-' + t + '-' + s;  
    },
    focusInput() {
      this.$refs.employeecode.focus();
    },
    checkValidate() {
     this.token = false;

     this.validate = true;
     this.nameError = false;
     this.employeeError = false;
     this.departmentError = false;
     this.emailError = false;
     var errors = [];
     //
     //
     // Check Empty 
            // check empty employee code
            if (this.newEmployeeCode == null || this.newEmployeeCode == '') {
                this.validate = false;
                this.employeeError = true;
                errors.push("Mã nhân viên không được để trống!");
            } 
            // check empty full name
            if (this.newFullName == null || this.newFullName == '') {
                this.validate = false;
                this.nameError = true;
                errors.push("Họ và tên không được để trống!");
            } 
            // check empty departmentid
            if (this.newDepartmentId == null || this.newDepartmentId == '') {
               this.validate = false;
               this.departmentError = true;
               errors.push("Đơn vị không được để trống!");
            } 
      //
      //
      //
          // Validate
             // check email 
                if (this.newEmail != null && this.newEmail != ''  && !this.validateEmail(this.newEmail)) {
                     this.validate = false;
                     this.emailError = true;
                     errors.push("Email chưa nhập đúng định dạng!");
                }
            // check employee code exists
                axios
                .get("https://localhost:44327/api/v1/Employees/CheckEmployeeCodeExist?m_EmployeeCode=" + this.newEmployeeCode)
                .then((response) => {
                    var codeCheck = response.data;
                    if (codeCheck && this.formMode == "add") {
                     this.validate = false;
                     this.employeeError = true;
                     errors.push("Mã nhân viên đã bị trùng!");
                    }
                    else if (codeCheck && this.formMode == "update") {
                       if (this.newEmployeeCode != this.employee.employeeCode) {
                         this.validate = false;
                         this.employeeError = true;
                         errors.push("Mã nhân viên đã bị trùng!");
                       }
                    }
                    if (this.validate) this.transformData();
                })
                .catch((res) => {
                 alert('Lỗi khi kiểm tra trùng mã nhân viên');
                    console.log(res.status);
                });  
       //
       //
       //
    },
    validateEmail(email) {
     var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
     return re.test(String(email).toLowerCase());
    },
    transformData() {
     var object;
     if (this.formMode == 'add') {
       object = {
        "employeeCode": this.newEmployeeCode,
        "fullName": this.newFullName,
        "dateOfBirth": this.newDateOfBirth,
        "gender": this.newGender,
        "departmentId": this.newDepartmentId,
        "identityNumber": this.newIdentityNumber,
        "identityDate": this.newIdentityDate,
        "identityPlace": this.newIdentityPlace,
        "jobTitle": this.newJobTitle,
        "address": this.newAddress,
        "phone": this.newPhone,
        "telephone": this.newTelephone,
        "email": this.newEmail,
        "bankAccount": this.newBankAccount,
        "bankName": this.newBankName,
        "bankBranch": this.newBankBranch,
       }
      axios.post("https://localhost:44327/api/v1/Employees", object).then((res) => 
                {
                    console.log(res);
                    alert('Thêm dữ liệu thành công');
                    this.btnCloseOnClick();
                    //window.location.reload();  
                })
                .catch((res) => {
                    console.log(res);
                    alert(res);
                    alert('Thêm dữ liệu không thành công');})
     }
     if (this.formMode == 'update') {
        object = {
         "EmployeeId" : this.employeeId,
        "EmployeeCode": this.newEmployeeCode,
        "FullName": this.newFullName,
        "DateOfBirth": this.newDateOfBirth,
        "Gender": this.newGender,
        "DepartmentId": this.newDepartmentId,
        "IdentityNumber": this.newIdentityNumber,
        "IdentityDate": this.newIdentityDate,
        "IdentityPlace": this.newIdentityPlace,
        "JobTitle": this.newJobTitle,
        "Address": this.newAddress,
        "Phone": this.newPhone,
        "Telephone": this.newTelephone,
        "Email": this.newEmail,
        "BankAccount": this.newBankAccount,
        "BankName": this.newBankName,
        "BankBranch": this.newBankBranch,
       }
       axios.put("https://localhost:44327/api/v1/Employees/"+ this.employeeId, object)
                .then((res) => {
                    console.log(res);
                    alert('Cập nhật dữ liệu thành công');
                    this.btnCloseOnClick();
                    // window.location.reload();  
                })
                .catch((res) => {
                    alert('Cập nhật dữ liệu không thành công');
                    console.log(res);
                })
     }
    }
  },
  data() {
   return {
        newEmployeeCode : null,
        newFullName : null,
        newDateOfBirth : null,
        newGender : null,
        newDepartmentId : null,
        newIdentityNumber : null,
        newIdentityDate : null,
        newIdentityPlace : null,
        newJobTitle : null,
        newAddress : null,
        newPhone : null,
        newTelephone : null,
        newEmail : null,
        newBankAccount : null,
        newBankName : null,
        newBankBranch : null,

        codeInvalid: false,
        nameError: false,
        employeeError: false,
        departmentError: false,
        emailError: false,
        validate: true,
   }
  }
}
</script>

<style scoped>
    .model {
    position: fixed;
    top: 0px;
    left: 0px;
    right: 0px;
    bottom: 0px;
    background-color: #000000;
    opacity: 0.4;
    }
    .dialog-hide {
    display: none;
    }
    .destroy{
        margin-left: 20px;
        margin-top: 20px;
        height: 36px;
    padding: 8px 20px;
    border: 1px solid #8d9096;
    color: #111;
    background-color: white;
    border-radius: 3px;
    cursor: pointer;
    }
    .destroy:hover{
        background-color: silver;
    }
    .save{
        margin-right: 20px;
        margin-top: 20px;
        height: 36px;
    padding: 8px 20px;
    border: 1px solid #8d9096;
    color: white;
    background-color: #2ca01c;;
    border-radius: 3px;
    cursor: pointer;
    }
    .save:hover{
        background-color: greenyellow;
    }
    .gender{
    position: relative;
    display: inline-flex;
    align-items: center;
    justify-content: flex-start;
    -webkit-box-align: center;
    -webkit-box-pack: center;
    }
    .ma{
        font-weight: bold;
        text-align: left;
        margin-left: 20px;
        margin-right: 130px;
        white-space: nowrap;
    }
    .dt_1{
        margin-right: 140px;
    }
    .dt_tknh{
        margin-right: 60px;
    }
    .email{
        margin-left: 140px;
    }
    .v1{
        height: 180px;
        width: 100%;      
        display: flex;
        
    }
    .mb{
     margin-left: 20px;
     margin-right: 10px;
    font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 160px;
    outline: none;
    }
    .mb-1{
        margin-right: 40px;
    }
    .mt{
        margin-left: 20px;
     margin-right: 0px;
    font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 200px;
    outline: none;
    }
    .mc{
        font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 250px;
    outline: none;
    }
    .md{
        margin-left: 20px;
        font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 410px;
    outline: none;
    }
    .me{
        margin-left: 20px;
     margin-right: 10px;
    font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 200px;
    outline: none;
    }
    .mf{
        outline: none;
        color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    font-size: 13px;
    height: 32px;
    }
    .mg{
        margin-left: 20px;
        outline: none;
        color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    font-size: 13px;
    height: 32px;
    width: 860px;
    }
    .mt-email{
        width: 300px;
    }
    .dt_cn{
        margin-left : 100px;
    }
    .m{
        display: flex;
        
    }
    .t{
        display: flex;
    }
    select{
        margin-left: 20px;
        font-size: 13px;
    height: 32px;
    color: inherit;
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    width: 420px;
    outline: none;
    }
    /* .m_t{
        display: flex;
    } */
    .v1_1{
       
        flex : 1;
    }
    .v1_2{
       
        flex : 1;
    }
    .v2{
        height: 240px;
        width: 100%;
        
    }
    .button-dialog{
        display: flex;
        justify-content: space-between;
        border-top: 1px solid #000;
    }
    .content_{
        height: 400px;
        width: 100%;
        overflow:hidden;
    }
    .content_::-webkit-scrollbar { 
        display: none; 
    }
    .dialog{
    min-width: 900px;
    max-width: 900px;
    width: 900px;
    border: 1px solid black;
    height: 550px;
    position: relative;
    margin-top: 0px;
    margin-left: 100px;
    display: block;
   background-color: white;
    z-index: 2;
    }
    .dialog-header {
        height: 76px;
        width: 100%;
        
        display: flex !important;
        font-family: inherit;
        font-size: inherit;
        position: relative;
        justify-content:space-between;
        
        /* box-sizing: border-box;
        outline: none;
        text-transform: none;
        text-decoration: none; */
    /* padding: 20px 32px;
    padding-right: 12px;
    position: relative;
    overflow: hidden;
    border-radius: 5px 5px 0 0; */
    }
    .dialog-content {
        height: 540px;
        width: 100%;
        
        /* display: flex;
       
        font-family: inherit;
        font-size: inherit;
        position: relative; */
        font-size: 13px;
        transition: all .23s ease .1s;
        flex-direction: column;
        display: flex;
        overflow: auto;
        overflow-y: visible;
        
    }
    .content_{
        overflow: auto;
    }
    .t{
        display: flex;
        padding-bottom: 10px;
    }
    .b{
        padding-top: 13px;
    }
    .close{
        float: right;
        font-size: 25px;
        margin-top: 10px;
        margin-right: 10px;
        cursor: pointer;
    }
    text-dialog-2{
        display: flex !important;
    }
    .text-header{
    font-family: inherit;
    font-size: inherit;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    white-space: nowrap;
    padding-top: 26px;
    font-size: 18px;
    margin-left : 10px;
    margin-right : 30px;
    }
    .title-dialog{
        
        font-size: 24px;
        color: #111;
        font-weight: 700;
        font-family: inherit;
        width: 100%;
    
        padding: 20px 25px;
    
    }
    .item-1{
        padding-top: 50px;
        width: 20px;
        height: 36px;
        cursor: pointer; 
        
    }
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
    
    .grid-model-control{
        min-width: 100%;
        margin: 0;
        padding: 0;
        -webkit-box-sizing: border-box;
        box-sizing: border-box;
        outline: none;
        text-transform: none;
        text-decoration: none;
    }
    .ms-grid-viewer{
        overflow: unset;
    max-height: none;
    min-width: calc(100% + 30px);
    font-family: inherit;
    font-size: inherit;
    margin: 0;
    padding: 0;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    color: #111;
    font-weight: 400;
    }
    .ms-table-viewer{
        border-spacing: 0;
    min-width: 100%;
    font-family: inherit;
    font-size: inherit;
        margin: 0;
    padding: 0;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    color: #111;
    }
    .ms-thead-viewer{
        font-family: inherit;
    font-size: inherit;
        margin: 0;
    padding: 0;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    border-spacing: 0;
    color: #111;
        font-weight: 400;
    }
    .ms-tr-viewer{
        font-family: inherit;
    font-size: inherit;
        margin: 0;
    padding: 0;
    -webkit-box-sizing: border-box;
    box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    border-spacing: 0;
    color: #111;
        font-weight: 400;
        direction: ltr;
        line-height: 1.5;
    letter-spacing: .01rem;
    }
    .ms-out-left-white-16{
        min-width: 16px;
    max-width: 16px;
    width: 16px;
    background: #fff;
    position: sticky;
    left: 0;
    border: 0;
    z-index: 3;
    padding: 0;
    text-align: left;
    font-size: .85rem;
    font-family: inherit;
        box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
    border-spacing: 0;
        color: #111;
    }
    
    .ms-muli-checkall{
        left: 16px;
        z-index: 3;
    
    min-width: 40px;
    width: 40px;
    max-width: 40px;
    border-right: 1px solid #c7c7c7;
    border-bottom: 1px solid #c7c7c7;
    min-height: 34px;
    height: 34px;
    background-color: #eceef1;
    vertical-align: middle;
        top: 93px!important;
        padding: 6px 10px;
    padding-top: 5px;
    padding-bottom: 3px;
    border: 0;
    text-align: left;
    font-size: .85rem;
        font-family: inherit;
        box-sizing: border-box;
    outline: none;
    text-transform: none;
    text-decoration: none;
        margin: 0;
            border-spacing: 0;
            border-collapse: separate;
    text-indent: initial;
    color: #111;
        direction: ltr;
            line-height: 1.5;
    letter-spacing: .01rem;
    }
    .con-ms-checkbox{
        color: #111;
            direction: ltr;
            line-height: 1.5;
    letter-spacing: .01rem;
    width: 10px;
    height: 10px;
    background: #b8bcc3;
    background: #f1f1f1;
    }
  
    .ms-tbody-viewer{
        line-height: 1.5;
    letter-spacing: .01rem;
        background-color: #fff;
        display: contents;
        color: #111;
        font-weight: 400;
    
    }
  
    .red-border {
     border: 1px solid red;
    }
    .m_1{
        margin-left:10px;
    }
    .dt_2{
        margin-left:10px;
    }
    .email{
        margin-left:160px;
    }
    .dt_3{
         margin-left:30px;
    }
    .dt_cn{
        margin-left:130px;
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