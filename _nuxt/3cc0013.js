(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{198:function(t,e,r){"use strict";var n=r(0),o=r(54),c=r(283),d=r(284);o.a.autoAddCss=!1,o.c.add(d.a),n.a.component("FaIcon",c.a)},270:function(t,e,r){var content=r(404);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,r(22).default)("56876578",content,!0,{sourceMap:!1})},271:function(t,e,r){var content=r(406);content.__esModule&&(content=content.default),"string"==typeof content&&(content=[[t.i,content,""]]),content.locals&&(t.exports=content.locals);(0,r(22).default)("dffcd638",content,!0,{sourceMap:!1})},286:function(t,e,r){"use strict";var n=r(432),o=r(436),c=r(433),d=r(191),l=r(124),f=r(194),v=r(80),m=r(435),w=r(434),h=(r(12),r(10),r(11),r(5),r(15),r(9),r(16),r(2)),x=r(81);function O(object,t){var e=Object.keys(object);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(object);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(object,t).enumerable}))),e.push.apply(e,r)}return e}function _(t){for(var i=1;i<arguments.length;i++){var source=null!=arguments[i]?arguments[i]:{};i%2?O(Object(source),!0).forEach((function(e){Object(h.a)(t,e,source[e])})):Object.getOwnPropertyDescriptors?Object.defineProperties(t,Object.getOwnPropertyDescriptors(source)):O(Object(source)).forEach((function(e){Object.defineProperty(t,e,Object.getOwnPropertyDescriptor(source,e))}))}return t}var y={data:function(){return{drawer:!1,group:null}},computed:_({},Object(x.c)({user:function(t){return t.user},loadingUser:function(t){return t.loading.user}})),watch:{group:function(){this.drawer=!1}},created:function(){this.getUser()},methods:_({},Object(x.b)({getUser:"getUser"}))},j=(r(403),r(70)),component=Object(j.a)(y,(function(){var t=this,e=t._self._c;return e(n.a,[e(o.a,{staticClass:"header accent--text",attrs:{color:"primary",app:"",fixed:"",short:"","clipped-left":""}},[e(c.a,{attrs:{color:"accent"},on:{click:function(e){e.stopPropagation(),t.drawer=!t.drawer}}}),t._v(" "),e(w.a),t._v(" "),e("div",{staticClass:"user d-flex flex-row"},[e("div",{staticClass:"monthly-score"},[t._v("\n          "+t._s(t.user.ThisMonthsScore)+"\n      ")]),t._v(" "),e("div",[t._v("\n        "+t._s(t.user.Name)+"\n      ")])])],1),t._v(" "),e(m.a,{attrs:{fixed:"",app:"",floating:"",clipped:""},model:{value:t.drawer,callback:function(e){t.drawer=e},expression:"drawer"}},[e(d.a,{attrs:{nav:"",dense:""}},[e(f.a,{attrs:{color:"secondary","active-class":"deep-purple--text text--accent-4"},model:{value:t.group,callback:function(e){t.group=e},expression:"group"}},[e(l.a,{attrs:{to:{name:"main"},exact:""},on:{click:function(e){e.stopPropagation(),t.drawer=!t.drawer}}},[e(v.b,[t._v("Main")])],1),t._v(" "),e(l.a,{attrs:{to:{name:"scoreboard"},exact:""},on:{click:function(e){e.stopPropagation(),t.drawer=!t.drawer}}},[e(v.b,[t._v("Scoreboard")])],1),t._v(" "),e(l.a,{attrs:{to:{name:"profile-id",params:{id:"user-id-goes-here"}},exact:""},on:{click:function(e){e.stopPropagation(),t.drawer=!t.drawer}}},[e(v.b,[t._v("Profile")])],1),t._v(" "),e(l.a,{attrs:{to:{name:"logout"},exact:""},on:{click:function(e){e.stopPropagation(),t.drawer=!t.drawer}}},[e(v.b,[t._v("Log out")])],1)],1)],1)],1),t._v(" "),e("Nuxt",{staticClass:"app"})],1)}),[],!1,null,"0930dae6",null);e.a=component.exports},287:function(t,e,r){"use strict";var n=r(432),o=(r(405),r(70)),component=Object(o.a)({},(function(){var t=this._self._c;return t(n.a,[t("Nuxt",{staticClass:"app"})],1)}),[],!1,null,"9d1dae64",null);e.a=component.exports},296:function(t,e,r){r(297),t.exports=r(298)},403:function(t,e,r){"use strict";r(270)},404:function(t,e,r){var n=r(21)(!1);n.push([t.i,".app[data-v-0930dae6]{height:100%;margin-top:56px}.user[data-v-0930dae6]{grid-gap:20px;gap:20px}",""]),t.exports=n},405:function(t,e,r){"use strict";r(271)},406:function(t,e,r){var n=r(21)(!1);n.push([t.i,".app[data-v-9d1dae64]{height:100%}",""]),t.exports=n},407:function(t,e,r){"use strict";r.r(e),r.d(e,"state",(function(){return o})),r.d(e,"mutations",(function(){return c})),r.d(e,"actions",(function(){return d}));var n=r(27),o=(r(93),function(){return{user:{Name:"John Doe",ThisMonthsScore:234562},loading:{user:!1},currentTask:{Id:1,Title:"Very important task",Description:"You need to quickly fix that leaking pipe in the office or there will be poop flood",Customer:"Jone Hop",PhoneNumber:"",Address:"",State:"",Score:135,Deleted:"",OwnerId:"",EstimatedTime:"",StartDate:"",CreatedBy:"",CreatedDate:"",UpdatedBy:"",UpdatedDate:""},tasks:[]}}),c={SET_USER:function(t,e){t.user=e}},d={getUser:function(t){return Object(n.a)(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:t.state,t.commit;case 1:case"end":return e.stop()}}),e)})))()},getTasks:function(t){return Object(n.a)(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){for(;;)switch(e.prev=e.next){case 0:t.state,t.commit;case 1:case"end":return e.stop()}}),e)})))()}}}},[[296,11,2,12]]]);