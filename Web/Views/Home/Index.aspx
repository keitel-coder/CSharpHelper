<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
    <meta http-equiv="Content-Type" content="text/html; charset=GBK" />
    <title>登录 开发者论坛 - </title>
    <meta name="keywords" content="" />
    <meta name="description" content=",开发者论坛" />
    <!--<base href="http://www.wpdever.net/">-->
    <base href="." />
    <link rel="stylesheet" type="text/css" href="./登录 开发者论坛 -_files/style_3_common.css" />
    <link rel="stylesheet" type="text/css" href="./登录 开发者论坛 -_files/style_3_member_logging.css" />
    <script src="/content/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">var STYLEID = '3', STATICURL = 'static/', IMGDIR = 'static/image/common', VERHASH = 'l0q', charset = 'gbk', discuz_uid = '0', cookiepre = '6pfD_2132_', cookiedomain = '', cookiepath = '/', showusercard = '1', attackevasive = '0', disallowfloat = 'login|newthread', creditnotice = '1|威望|,2|金钱|,3|贡献|', defaultstyle = '', REPORTURL = 'aHR0cDovL3d3dy53cGRldmVyLm5ldC9tZW1iZXIucGhwP21vZD1sb2dnaW5nJmFjdGlvbj1sb2dpbg==', SITEURL = 'http://www.wpdever.net/', JSPATH = 'data/cache/', DYNAMICURL = '';</script>
    <script src="/content/js/common.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="./登录 开发者论坛 -_files/newry.css" media="all" />
    <script language="javascript" type="text/javascript">
        function killerrors() {
            return true;
        }
        window.onerror = killerrors;
    </script>
    <meta name="application-name" content="开发者论坛" />
    <meta name="msapplication-tooltip" content="开发者论坛" />
    <meta name="msapplication-task" content="name=门户;action-uri=http://www.wpdever.net/portal.php;icon-uri=http://www.wpdever.net/static/image/common/portal.ico" />
    <meta name="msapplication-task" content="name=论坛;action-uri=http://www.wpdever.net/forum.php;icon-uri=http://www.wpdever.net/static/image/common/bbs.ico" />
    <meta name="msapplication-task" content="name=;action-uri=http://www.wpdever.net/group.php;icon-uri=http://www.wpdever.net/static/image/common/group.ico" />
    <script src="http://tajs.qq.com/stats?sId=34664106" type="text/javascript" charset="UTF-8"></script>
</head>
<!--腾讯云分析嵌入代码-->

<body id="nv_member" class="pg_logging" onkeydown="if(event.keyCode==27) return false;">
    <div id="append_parent">
        <div id="loginfield_LzQq7_ctrl_menu" class="sltm" style="display: none; width: 45px;">
            <ul>
                <li class="current">用户名</li>
                <li>Email</li>
            </ul>
        </div>
    </div>
    <div id="ajaxwaitid"></div>
    <div id="newry_topnav" class="nav_box">
        <div class="nav_min cl">
            <div class="logo">
                <h1>
                    <a href="http://www.wpdever.net/" title="开发者论坛">
                        <img src="./登录 开发者论坛 -_files/logo.png" alt="开发者论坛" border="0" /></a>
                </h1>
            </div>
            <!--Start Navigation-->
            <div id="newry_menu_nav" class="newry_m_n">

                <li id="mn_forum"><a href="http://www.wpdever.net/forum.php" hidefocus="true" title="BBS">论坛<span>BBS</span></a></li>

                <li id="mn_Ncc66"><a href="http://www.wpdever.net/forum.php?mod=guide&view=my" hidefocus="true">帖子</a></li>

                <li id="mn_Nc14f"><a href="http://www.wpdever.net/group.php" hidefocus="true">群组</a></li>

                <li id="mn_N7256"><a href="http://www.wpdever.net/home.php?mod=space&do=favorite&view=me" hidefocus="true">收藏</a></li>

                <li id="mn_N59a5"><a href="http://www.wpdever.net/baidufm.php" hidefocus="true" target="_blank">音乐</a></li>
            </div>
            <!-- Block user information module HEADER -->
            <div class="newry_login"><a href="http://www.wpdever.net/connect.php?mod=login&op=init&referer=forum.php&statfrom=login"><em class="i_qq"></em></a></div>
            <div id="newry_user">
                <ul id="newry_nav">
                    <li id="login_u_box"><span><a href="javascript:;" onclick="javascript:lsSubmit();" class="nousername">登录</a></span> <span><a href="http://www.wpdever.net/member.php?mod=register" class="btn-register">注册</a></span> </li>
                </ul>
            </div>
            <div style="display: none">
            </div>
            <!-- /Block user information module HEADER -->
            <ul id="umnav_menu" class="p_pop nav_pop" style="display: none;">
                <p class="newry_arrow"></p>
                <li><a class="infos" href="http://www.wpdever.net/home.php?mod=space&uid=0" target="_blank" title="访问我的空间"></a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=spacecp&ac=credit&showcredit=1" id="extcreditmenu">积分: 0</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=spacecp">设置</a></li>
                <li><a href="http://www.wpdever.net/forum.php?mod=guide&view=my" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/thread_b.png) !important">帖子</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=space&do=friend" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/friend_b.png) !important">好友</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=space&do=favorite&view=me" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/favorite_b.png) !important">收藏</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=magic" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/magic_b.png) !important">道具</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=medal" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/medal_b.png) !important">勋章</a></li>
                <li><a href="http://www.wpdever.net/home.php?mod=space&do=wall" _style="background-image:url(http://bbs.wpdever.net/static/image/feed/wall_b.png) !important">留言板</a></li>
                <li><a href="http://www.wpdever.net/member.php?mod=logging&action=logout&formhash=5d902445">退出</a></li>
            </ul>
            <div id="scbar" class="cl">
                <form id="scbar_form" method="post" autocomplete="off" onsubmit="searchFocus($(&#39;scbar_txt&#39;))" action="http://www.wpdever.net/search.php?searchsubmit=yes" target="_blank">
                    <input type="hidden" name="mod" id="scbar_mod" value="forum" />
                    <input type="hidden" name="formhash" value="5d902445" />
                    <input type="hidden" name="srchtype" value="title" />
                    <input type="hidden" name="srhfid" value="0" />
                    <input type="hidden" name="srhlocality" value="member::logging" />
                    <input type="text" name="srchtxt" id="scbar_txt" value="请输入搜索内容" autocomplete="off" class=" xg1" placeholder="请输入搜索内容" />
                    <a href="javascript:;" id="scbar_type" class="showmenu" onclick="showMenu(this.id)" hidefocus="true">帖子</a>
                    <button type="submit" name="searchsubmit" id="scbar_btn" sc="1" value="true" mid="lVUTkRUmgWWWWWWWWWWWWWWWWWWWWWWW">搜索</button>
                </form>
            </div>
            <ul id="scbar_type_menu" class="p_pop" style="display: none;">
                <li><a href="javascript:;" rel="article">文章</a></li>
                <li><a href="javascript:;" rel="forum" class="curtype">帖子</a></li>
                <li><a href="javascript:;" rel="group"></a></li>
                <li><a href="javascript:;" rel="user">用户</a></li>
            </ul>
            <script type="text/javascript">
                initSearchmenu('scbar', '');
            </script>
            <div class="cl"></div>
        </div>
        <script src="./登录 开发者论坛 -_files/scrolltop.js" type="text/javascript"></script>
        <!--End Navigation-->
        <div class="p_pop h_pop" id="mn_userapp_menu" style="display: none"></div>
        <div id="mu" class="cl">
        </div>

    </div>
    <div class="cl"></div>
    <div id="wp" class="wp">
        <div id="ct" class="ptm wp w cl">
            <div class="nfl" id="main_succeed" style="display: none">
                <div class="f_c altw">
                    <div class="alert_right">
                        <p id="succeedmessage"></p>
                        <p id="succeedlocation" class="alert_btnleft"></p>
                        <p class="alert_btnleft"><a id="succeedmessage_href">如果您的浏览器没有自动跳转，请点击此链接</a></p>
                    </div>
                </div>
            </div>
            <div class="mn" id="main_message">
                <div class="bm">
                    <div class="bm_h bbs">
                        <span class="y">
                            <a href="http://www.wpdever.net/member.php?mod=register" class="xi2">没有帐号？</a><a href="http://www.wpdever.net/member.php?mod=register">立即注册</a>
                        </span>
                        <h3 class="xs2">登录</h3>
                    </div>
                    <div>
                        <div id="main_messaqge_LzQq7">
                            <div id="layer_login_LzQq7">
                                <h3 class="flb">
                                    <em id="returnmessage_LzQq7"></em>
                                    <span></span>
                                </h3>
                                <form method="post" autocomplete="off" name="login" id="loginform_LzQq7" class="cl" onsubmit="pwdclear = 1;ajaxpost(&#39;loginform_LzQq7&#39;, &#39;returnmessage_LzQq7&#39;, &#39;returnmessage_LzQq7&#39;, &#39;onerror&#39;);return false;" action="http://www.wpdever.net/member.php?mod=logging&action=login&loginsubmit=yes&loginhash=LzQq7">
                                    <div class="c cl">
                                        <input type="hidden" name="formhash" value="5d902445" />
                                        <input type="hidden" name="referer" value="http://www.wpdever.net/" />
                                        <div class="rfm">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>
                                                            <span class="login_slct">
                                                                <select name="loginfield" style="float: left; display: none;" width="45" id="loginfield_LzQq7" selecti="0">

                                                                    <option value="username"></option>
                                                                </select><a href="javascript:;" id="loginfield_LzQq7_ctrl" style="width: 45px" tabindex="1">用户名</a>
                                                            </span>
                                                        </th>
                                                        <td>
                                                            <input type="text" name="username" id="username_LzQq7" autocomplete="off" size="30" class="px p_fre" tabindex="1" value="" /></td>
                                                        <td class="tipcol"><a href="http://www.wpdever.net/member.php?mod=register">立即注册</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>
                                                            <label for="password3_LzQq7">密码:</label></th>
                                                        <td>
                                                            <input type="password" id="password3_LzQq7" name="password" onfocus="clearpwd()" size="30" class="px p_fre" tabindex="1" /></td>
                                                        <td class="tipcol"><a href="javascript:;" onclick="display(&#39;layer_login_LzQq7&#39;);display(&#39;layer_lostpw_LzQq7&#39;);" title="找回密码">找回密码</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>安全提问:</th>
                                                        <td>
                                                            <select id="loginquestionid_LzQq7" width="213" name="questionid" onchange="if($(&#39;loginquestionid_LzQq7&#39;).value &gt; 0) {$(&#39;loginanswer_row_LzQq7&#39;).style.display=&#39;&#39;;} else {$(&#39;loginanswer_row_LzQq7&#39;).style.display=&#39;none&#39;;}">
                                                                <option value="0">安全提问(未设置请忽略)</option>
                                                                <option value="1">母亲的名字</option>
                                                                <option value="2">爷爷的名字</option>
                                                                <option value="3">父亲出生的城市</option>
                                                                <option value="4">您其中一位老师的名字</option>
                                                                <option value="5">您个人计算机的型号</option>
                                                                <option value="6">您最喜欢的餐馆名称</option>
                                                                <option value="7">驾驶执照最后四位数字</option>
                                                            </select>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm" id="loginanswer_row_LzQq7" style="display: none">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>答案:</th>
                                                        <td>
                                                            <input type="text" name="answer" id="loginanswer_LzQq7" autocomplete="off" size="30" class="px p_fre" tabindex="1" /></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>

                                        <div class="rfm ">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th></th>
                                                        <td>
                                                            <label for="cookietime_LzQq7">
                                                                <input type="checkbox" class="pc" name="cookietime" id="cookietime_LzQq7" tabindex="1" value="2592000" />自动登录</label></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm mbw bw0">
                                            <table width="100%">
                                                <tbody>
                                                    <tr>
                                                        <th>&nbsp;</th>
                                                        <td>
                                                            <button class="pn pnc" type="submit" name="loginsubmit" value="true" tabindex="1"><strong>登录</strong></button>
                                                        </td>
                                                        <td>
                                                            <a href="javascript:;" onclick="ajaxget(&#39;member.php?mod=clearcookies&amp;formhash=5d902445&#39;, &#39;returnmessage_LzQq7&#39;, &#39;returnmessage_LzQq7&#39;);return false;" title="清除痕迹" class="y">清除痕迹</a>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm bw0  mbw">
                                            <hr class="l" />
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>快捷登录:</th>
                                                        <td>
                                                            <a href="http://www.wpdever.net/connect.php?mod=login&op=init&referer=http%3A%2F%2Fwww.wpdever.net%2F&statfrom=login" target="_top" rel="nofollow">
                                                                <img src="/content/images/qq_login.gif" class="vm" /></a>

                                                            <a href="http://www.wpdever.net/plugin.php?id=wechat:login">
                                                                <img src="/content/images/wechat_login.png" class="vm" />
                                                            </a><a rel="nofollow" target="_top" href="https://api.weibo.com/oauth2/authorize?client_id=3176941170&redirect_uri=http://login.wpdever.net&response_type=code">
                                                                <img class="vm" src="/content/images/weibo_login.png" /></a>
                                                            <a href="http://www.wpdever.net/plugin.php?id=niuc_baiduconnect:connect&op=bindaccount">
                                                                <img src="/content/images/login-short2.png" align="absmiddle" alt="绑定百度帐户" style="cursor: pointer" class="vm" /></a>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div id="layer_lostpw_LzQq7" style="display: none;">
                                <h3 class="flb">
                                    <em id="returnmessage3_LzQq7">找回密码</em>
                                    <span></span>
                                </h3>
                                <form method="post" autocomplete="off" id="lostpwform_LzQq7" class="cl" onsubmit="ajaxpost(&#39;lostpwform_LzQq7&#39;, &#39;returnmessage3_LzQq7&#39;, &#39;returnmessage3_LzQq7&#39;, &#39;onerror&#39;);return false;" action="http://www.wpdever.net/member.php?mod=lostpasswd&lostpwsubmit=yes&infloat=yes">
                                    <div class="c cl">
                                        <input type="hidden" name="formhash" value="5d902445" />
                                        <input type="hidden" name="handlekey" value="lostpwform" />
                                        <div class="rfm">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th><span class="rq">*</span><label for="lostpw_email">Email:</label></th>
                                                        <td>
                                                            <input type="text" name="email" id="lostpw_email" size="30" value="" tabindex="1" class="px p_fre" /></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th>
                                                            <label for="lostpw_username">用户名:</label></th>
                                                        <td>
                                                            <input type="text" name="username" id="lostpw_username" size="30" value="" tabindex="1" class="px p_fre" /></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div class="rfm mbw bw0">
                                            <table>
                                                <tbody>
                                                    <tr>
                                                        <th></th>
                                                        <td>
                                                            <button class="pn pnc" type="submit" name="lostpwsubmit" value="true" tabindex="100"><span>提交</span></button></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <div id="layer_message_LzQq7" class="f_c blr nfl" style="display: none;">
                            <h3 class="flb" id="layer_header_LzQq7"></h3>
                            <div class="c">
                                <div class="alert_right">
                                    <div id="messageleft_LzQq7"></div>
                                    <p class="alert_btnleft" id="messageright_LzQq7"></p>
                                </div>
                            </div>
                            <script type="text/javascript" reload="1">
                                var pwdclear = 0;
                                function initinput_login() {
                                    document.body.focus();
                                    if ($('loginform_LzQq7')) {
                                        $('loginform_LzQq7').username.focus();
                                    }
                                    simulateSelect('loginfield_LzQq7');
                                }
                                initinput_login();

                                function clearpwd() {
                                    if (pwdclear) {
                                        $('password3_LzQq7').value = '';
                                    }
                                    pwdclear = 0;
                                }
                            </script>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="a_cn" style="">
        <p class="close" id="ad_corner_close" onclick="setcookie(&#39;adclose_7&#39;, 1, 86400);this.parentNode.style.display=&#39;none&#39;">
            <a href="javascript:;">
                <img src="http://www.wpdever.net/static/image/common/ad_close.gif" style="display: none !important;" /></a>
        </p>
        <a href="http://s.click.taobao.com/t?e=m%3D2%26s%3DeMIKocg0R5kcQipKwQzePCperVdZeJvipRe%2F8jaAHci5VBFTL4hn2RDQ%2FZ7WY5L0P9LlJoUu0c6kP6U623qigqyqUcrkOM6i%2FTsEKU8%2Fc04UkYPEKHVCtb0CYBEjBf0r%2BX0J8NM6NNe3guBJbDHkrvB0z8qlrv%2Bj%2FYdPBexeuF7B1c9CTg2lWhg%2BzwaRZ05aznq15oWgOQFYrxMSwYKz1qJn5AyUbPoV" target="_blank">
            <img src="./登录 开发者论坛 -_files/T1fBKUFwxXXXbTMG7M-440-180.jpg" alt="女装KA秒杀会场" border="0" /></a>
    </div>

    <script type="text/javascript">
        _attachEvent(window, 'load', getForbiddenFormula, document);
        function getForbiddenFormula() {
            var toGetForbiddenFormulaFIds = function () {
                ajaxget('plugin.php?id=cloudsearch&formhash=5d902445');
            };
            var a = document.body.getElementsByTagName('a');
            for (var i = 0; i < a.length; i++) {
                if (a[i].getAttribute('sc')) {
                    a[i].setAttribute('mid', hash(a[i].href));
                    a[i].onmousedown = function () { toGetForbiddenFormulaFIds(); };
                }
            }
            var btn = document.body.getElementsByTagName('button');
            for (var i = 0; i < btn.length; i++) {
                if (btn[i].getAttribute('sc')) {
                    btn[i].setAttribute('mid', hash(btn[i].id));
                    btn[i].onmousedown = function () { toGetForbiddenFormulaFIds(); };
                }
            }
        }
    </script>


    <div style="display: block; overflow: hidden; height: 50px; width: 960px; margin: 0 auto"></div>

    <!-- footer begin -->
    <div id="ft" class="footer qyer_footer">

        <div class="wp">
            <p>
                <em></em>
                (<a href="http://www.miitbeian.gov.cn/" target="_blank">湘ICP备14008895号</a>)<em></em>            &nbsp;<a href="http://discuz.qq.com/service/security" target="_blank" title="防水墙保卫网站远离侵害"><img src="./登录 开发者论坛 -_files/security.png" /></a>
                <script type="text/javascript">var cnzz_protocol = (("https:" == document.location.protocol) ? " https://" : " http://"); document.write(unescape("%3Cspan id='cnzz_stat_icon_5860807'%3E%3C/span%3E%3Cscript src='" + cnzz_protocol + "s5.cnzz.com/stat.php%3Fid%3D5860807%26show%3Dpic1' type='text/javascript'%3E%3C/script%3E"));</script>
                <span id="cnzz_stat_icon_5860807"></span>
                <script src="http://s5.cnzz.com/stat.php?id=5860807&show=pic1" type="text/javascript"></script>
                <em></em>
                <a href="tencent://message/?uin=549322842+&Site=%E5%BC%80%E5%8F%91%E8%80%85%E8%AE%BA%E5%9D%9B&Menu=yes" target="_blank" title="QQ">
                    <img src="/content/images/site_qq.jpg" alt="QQ" style="vertical-align: middle;" /></a>
            </p>
            Powered by <a href="http://www.discuz.net/" target="_blank">discuz</a>X3.2 , All rights reserved.<span></span><a href="http://www.wpdever.net/" target="_blank">开发者论坛</a> 版权所有<br />
        </div>
    </div>
    <!-- footer end -->
    <div id="scrolltop">
        <span hidefocus="true"><a title="返回顶部" onclick="window.scrollTo(&#39;0&#39;,&#39;0&#39;)" class="scrolltopa"><b>返回顶部</b></a></span>
    </div>
    <script type="text/javascript">_attachEvent(window, 'scroll', function () { showTopLink(); }); checkBlind();</script>
    <div id="discuz_tips" style="display: none;"></div>
    <script type="text/javascript">
        var tipsinfo = '34664106|X3.2|0.6||0||0|7|1413380248|2d0914e0f52dcffd3076aa2502f80ca9|2';
    </script>
    <script src="http://discuz.gtimg.cn/cloud/scripts/discuz_tips.js?v=1" type="text/javascript" charset="UTF-8"></script>
    <div id="__nightingale_view_cover" style="width: 100%; height: 100%; -webkit-transition: -webkit-transform 10s ease-in-out; transition: -webkit-transform 10s ease-in-out; position: fixed !important; left: 0px !important; bottom: 0px !important; overflow: hidden !important; pointer-events: none !important; z-index: 2147483647; opacity: 0; background: rgb(0, 0, 0) !important;"></div>
</body>
</html>
