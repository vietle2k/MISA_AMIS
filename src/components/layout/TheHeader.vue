<template>
    <div class="header">
        <div class="vs-con-items">
            <div class="header-icon mi mi-24 mi-three-stripes pointer"></div>
            <div class="flex header-branch">
                <div class="con-ms-tooltip">
                    <div class="msTooltipParent"></div>
                    <div class="tooltip-content">
                        <div class="header-branch-name">CÔNG TY TNHH SẢN XUẤT - THƯƠNG MẠI - DỊCH VỤ QUI PHÚC</div>
                    </div>
                </div>
                <a class="flex items-center">
                    <div class="header-icon mi mi-14 mi-chevron-right header-branch-icon pointer"></div>
                </a>
            </div>
            <div class="right-side">
                <div class="notify">
                    <div class="con-ms-tooltip header-menu-icon">
                        <div class="msTooltipParent"></div>
                        <div class="tooltip-content">
                            <div class="pointer header-icon">
                                <div class="wrap-notify header-menu-icon-simple">
                                    <div class="mi mi-24 mi-bell__nav wiggle"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="ms-notify" notifyno="0"></div>
                </div>
                <div class="account-info">
                    <div class="dropdown-secondary ms-dropdown">
                        <button class="ms-component ms-button ms-con-dropdown parent-dropdown expand-more-button ms-button-size-default ms-button-secondary ms-button-secondary-disabled-false ms-button-radius-false ms-button ms-dropdown-type-secondary ms-con-dropdown-radius-true-false ms-con-dropdown-radius-true-secondary ms-padding-is-single-true-size-default ms-dropdown-style ms-con-dropdown parent-dropdown expand-more-button">
                        <div class="ms-button-text ms-button--text flex align-center">
                            <div class="flex items-center ms-dropdown-user">
                                <div class="user-avatar">
                                    <div class="mi mi-32 mi-user-avatar avatar"></div>
                                 </div>
                                <div class="user-name">
                                    <div class="pr-6 display-user">Lê Xuân Việt</div>
                                </div>
                                <div class="mi mi-14 mi-chevron-down header-branch-icon pointer rotate-45 align-center"></div>
                            </div>
                        </div>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
@import '../../style/Dropdown.css';
    .header {
        position: absolute;
        left: 178px;
        top: 0;
        background-color: rgb(255 255 255);
        height: 48px;
        width: calc(100% - 214px);
        display: flex;
        padding-right: 36px;
    }

        .header .vs-con-items {
            display: flex;
            -webkit-box-align: center;
            align-items: center;
            -webkit-box-pack: center;
            justify-content: center;
        }

    .header-icon {
        margin: 0 10px;
    }

    .header-branch {
        cursor: pointer;
        align-items: center;
    }

    .header-branch-name {
        padding-left: 10px;
        overflow: hidden;
        white-space: nowrap;
        font-weight: 600;
        max-width: 800px;
        text-overflow: ellipsis;
        transition: all .2s ease;
        font-size: 14px;
        color: #111;
    }

    .header-branch-icon {
        transform: rotate(90deg);
        margin-left: 10px;
    }

    .flex {
        display: flex!important;
    }

    .con-ms-tooltip .header-menu-icon {
        position: relative;
        height: 48px;
        width: 44px;
    }

    .right-side {
        position: absolute;
        right: 0;
        display: flex;
        align-items: center;
    }

    .notify {
        position: relative;
    }

    .align-center {
        justify-content: center;
        align-items: center;
    }

    .ms-button .ms-button--text {
        position: relative;
        color: inherit;
        display: inline-block;
        transition: all .25s ease;
        white-space: nowrap;
        font-size: 13px;
        line-height: 13px;
    }

    .dropdown-secondary .ms-button-secondary .ms-button-text .ms-dropdown-user .user-name {
        align-items: center;
        color: #111;
        font-size: 14px;
        display: flex;
        margin-right: 8px;
        font-family: 'notosans-bold.3ede5aff';
    }

    .dropdown-secondary .ms-component.ms-button {
        padding: 0 30px !important;
    }

    .rotate-45 {
        transform: rotate(0deg);
    }
    
    @media (max-width: 920px) {
        .header-branch-name {
            max-width: 100px;
        }

        .notify {
            display: none;
        }
    }
    @font-face {
        font-family: 'notosans-bold.3ede5aff';
        src: url('../../assets/fonts/notosans-bold.3ede5aff.woff2') format('woff2');
    }
</style>