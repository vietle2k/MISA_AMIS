<template>
    <div style="display: flex; justify-content: center; align-items:center; cursor: pointer;">
        <div style="color: blue;" @click="showEmployeeDetail()">Sửa</div> 
        <button id="dropdown-icon" @click="showDropContent()"></button>
        <div id="dropdown">     
            <div class="dropdown-content" :class="{'hide': !isShowOption}" >
                <div class="dropdown-content-a">Nhân bản</div>
                <div class="dropdown-content-a" @click="showDeleteDialog()">Xóa</div>
                <div class="dropdown-content-a">Ngưng dùng</div>
            </div>
        </div>
    </div>
</template>
<script>
export default ({
    props:{
        employeeId: { type: String, default: null },
        employeeName: { type: String, default: null },
    },
    created() {
        
    },
    
    methods: {
        
        //Hiện ra các thông tin tùy chọn để select (dropdown-option)
        showDropContent() {
            // if(this.isShowOption == true) 
            // else this.isShowOption = true;
            //this.isShowOption = true;
            if (this.isShowOption) {
                this.isShowOption = false;
            } else this.isShowOption = true;
        },
        //Ẩn dropdown-option
        hideDropContent(){
            this.isShowOption = false;
        },
        //Hiện dialog để xác nhận xóa nhân viên
        showDeleteDialog(){
            this.$emit('showDeleteDialog');
        },
        //Hiện dialog chi tiết thông tin nhân viên
        showEmployeeDetail(){
            this.$emit('showEmployeeDetail');
        }
    },
    data() {
        return {
            
            //Hiện/Ẩn option sửa/xóa
            isShowOption: false,
        }
    },
})
</script>

<style scoped>
    #dropdown{
        position: relative;
        display: inline-block;
    }
    #dropdown-icon{
        width: 20px;
        height: 16px;
        min-width: 16px;
        min-height: 16px;
        background: url(../../assets/img/Sprites.64af8f61.svg) no-repeat;
        cursor: pointer;
        background-position: -890px -359px;
        border: none;
    }
    .dropdown-content{
        
        position: absolute;
        right: 0px;
        top: 10px;
        background-color: #fff;
        /* min-width: 160px; */
        overflow: auto;
        width: 100px;
        height: 75px;
        border: 1px solid #babec5;
        box-sizing: border-box;
        border-radius: 4px;
    }
    .dropdown-content-a{
        height: 24px;
        width: 100%;
        display: flex;
        align-items: center;
        padding-left: 4px;
        box-sizing: border-box;
        border: none;
        outline: none;
    }
    .dropdown-content-a:hover{
        background-color: #f1f1f1;
        cursor: pointer;
        color: #2ca01c;
    }
    .hide{
        display: none;
    }
</style>
