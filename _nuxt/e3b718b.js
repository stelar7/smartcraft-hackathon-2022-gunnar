(window.webpackJsonp=window.webpackJsonp||[]).push([[2],{196:function(e,t,r){"use strict";var o=r(0),n=r(53),c=r(281),d=r(282);n.a.autoAddCss=!1,n.c.add(d.a),o.a.component("FaIcon",c.a)},197:function(e,t,r){"use strict";var o=r(283);t.a=function(e){var t=e.store;Object(o.a)({storage:window.sessionStorage})(t)}},268:function(e,t,r){var content=r(404);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,r(22).default)("57d9d86a",content,!0,{sourceMap:!1})},269:function(e,t,r){var content=r(406);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[e.i,content,""]]),content.locals&&(e.exports=content.locals);(0,r(22).default)("dffcd638",content,!0,{sourceMap:!1})},285:function(e,t,r){"use strict";var o=r(431),n=r(435),c=r(432),d=r(189),l=r(191),f=r(124),m=r(192),h=r(80),v=r(434),w=r(433),y=(r(11),r(10),r(12),r(5),r(15),r(9),r(16),r(2)),x=r(79);function k(object,e){var t=Object.keys(object);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(object);e&&(r=r.filter((function(e){return Object.getOwnPropertyDescriptor(object,e).enumerable}))),t.push.apply(t,r)}return t}function O(e){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?k(Object(source),!0).forEach((function(t){Object(y.a)(e,t,source[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(source)):k(Object(source)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(source,t))}))}return e}var D={data:function(){return{drawer:!1,group:null}},computed:O({},Object(x.d)({user:function(e){return e.user},loadingUser:function(e){return e.loading.user}})),watch:{group:function(){this.drawer=!1}},created:function(){this.getUser()},methods:O({},Object(x.b)({getUser:"getUser"}))},_=(r(403),r(69)),component=Object(_.a)(D,(function(){var e=this,t=e._self._c;return t(o.a,[t(n.a,{staticClass:"header accent--text",attrs:{color:"primary",app:"",fixed:"",short:"","clipped-left":""}},[t(c.a,{attrs:{color:"accent"},on:{click:function(t){t.stopPropagation(),e.drawer=!e.drawer}}}),e._v(" "),t(w.a),e._v(" "),t("div",{staticClass:"user d-flex flex-row"},[t("div",{staticClass:"monthly-score"},[t(d.a,{attrs:{color:"primary",size:"40"}},[t("fa-icon",{staticClass:"icon amber--text",attrs:{icon:["fa","trophy"]}})],1),e._v("\n\n          "+e._s(e.user.ThisMonthsScore)+"\n      ")],1),e._v(" "),t("div",[t(d.a,{attrs:{color:"accent",size:"40"}},[t("fa-icon",{staticClass:"icon primary--text",attrs:{icon:["fa","user"]}})],1),e._v("\n\n        "+e._s(e.user.Name)+"\n      ")],1)])],1),e._v(" "),t(v.a,{attrs:{fixed:"",app:"",floating:"",clipped:""},model:{value:e.drawer,callback:function(t){e.drawer=t},expression:"drawer"}},[t(l.a,{attrs:{nav:"",dense:""}},[t(m.a,{attrs:{color:"secondary","active-class":"deep-purple--text text--accent-4"},model:{value:e.group,callback:function(t){e.group=t},expression:"group"}},[t(f.a,{attrs:{to:{name:"index"},exact:""},on:{click:function(t){t.stopPropagation(),e.drawer=!e.drawer}}},[t(h.a,[e._v("Main")])],1),e._v(" "),t(f.a,{attrs:{to:{name:"scoreboard"},exact:""},on:{click:function(t){t.stopPropagation(),e.drawer=!e.drawer}}},[t(h.a,[e._v("Scoreboard")])],1),e._v(" "),t(f.a,{attrs:{to:{name:"profile-id",params:{id:"user-id-goes-here"}},exact:""},on:{click:function(t){t.stopPropagation(),e.drawer=!e.drawer}}},[t(h.a,[e._v("Profile")])],1),e._v(" "),t(f.a,{attrs:{to:{name:"logout"},exact:""},on:{click:function(t){t.stopPropagation(),e.drawer=!e.drawer}}},[t(h.a,[e._v("Log out")])],1)],1)],1)],1),e._v(" "),t("Nuxt",{staticClass:"app"})],1)}),[],!1,null,"8543ab9c",null);t.a=component.exports},286:function(e,t,r){"use strict";var o=r(431),n=(r(405),r(69)),component=Object(n.a)({},(function(){var e=this._self._c;return e(o.a,[e("Nuxt",{staticClass:"app"})],1)}),[],!1,null,"9d1dae64",null);t.a=component.exports},290:function(e,t,r){r(291),e.exports=r(292)},329:function(e,t,r){"use strict";r.r(t),t.default=function(e){e.$vuetify.theme.dark=e.store.state.isDarkTheme}},403:function(e,t,r){"use strict";r(268)},404:function(e,t,r){var o=r(21)(!1);o.push([e.i,".app[data-v-8543ab9c]{height:100%;margin-top:56px;background:#f6f4f2}.user[data-v-8543ab9c]{grid-gap:20px;gap:20px}.icon[data-v-8543ab9c]{width:35px;height:35px}",""]),e.exports=o},405:function(e,t,r){"use strict";r(269)},406:function(e,t,r){var o=r(21)(!1);o.push([e.i,".app[data-v-9d1dae64]{height:100%}",""]),e.exports=o},407:function(e,t,r){"use strict";r.r(t),r.d(t,"state",(function(){return d})),r.d(t,"mutations",(function(){return l})),r.d(t,"actions",(function(){return f}));var o=r(28),n=(r(102),r(89)),c=r.n(n),d=function(){return{isDarkTheme:!1,user:{Name:"John Doe",ThisMonthsScore:3500},loading:{user:!1},currentTask:{Id:1,Title:"Very important task",Description:"You need to quickly fix that leaking pipe in the office or there will be poop flood",Customer:"Jone Hop",PhoneNumber:"77442634",Address:"Some street 2, 2322 City",State:"",Score:135,Deleted:"",OwnerId:"",EstimatedTime:"",StartDate:"05.10.2022",CreatedBy:"",CreatedDate:"",UpdatedBy:"",UpdatedDate:""},tasks:[{Id:3,Title:"Very important task 3",Description:"You need to quickly fix that leaking pipe in the office or there will be poop flood",Customer:"Jone Hop",PhoneNumber:"77442634",Address:"Some street 2, 2322 City",State:"",Score:135,Deleted:"",OwnerId:"",EstimatedTime:"",StartDate:"05.10.2022",CreatedBy:"",CreatedDate:"",UpdatedBy:"",UpdatedDate:""},{Id:4,Title:"Very important task 4",Description:"You need to quickly fix that leaking pipe in the office or there will be poop flood",Customer:"Jone Hop",PhoneNumber:"77442634",Address:"Some street 2, 2322 City",State:"",Score:135,Deleted:"",OwnerId:"",EstimatedTime:"",StartDate:"05.10.2022",CreatedBy:"",CreatedDate:"",UpdatedBy:"",UpdatedDate:""},{Id:5,Title:"Very important task 5",Description:"You need to quickly fix that leaking pipe in the office or there will be poop flood",Customer:"Jone Hop",PhoneNumber:"77442634",Address:"Some street 2, 2322 City",State:"",Score:135,Deleted:"",OwnerId:"",EstimatedTime:"",StartDate:"05.10.2022",CreatedBy:"",CreatedDate:"",UpdatedBy:"",UpdatedDate:""}]}},l={SET_USER:function(e,t){e.user=t},changeTheme:function(e,t){e.isDarkTheme=t}},f={getUser:function(e){return Object(o.a)(regeneratorRuntime.mark((function t(){var r;return regeneratorRuntime.wrap((function(t){for(;;)switch(t.prev=t.next){case 0:return e.state,e.commit,t.next=3,c.a.get("http://localhost:8082/api/User");case 3:return r=t.sent,t.abrupt("return",r.data);case 5:case"end":return t.stop()}}),t)})))()},getTasks:function(e){return Object(o.a)(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){for(;;)switch(t.prev=t.next){case 0:e.state,e.commit;case 1:case"end":return t.stop()}}),t)})))()}}}},[[290,11,3,12]]]);