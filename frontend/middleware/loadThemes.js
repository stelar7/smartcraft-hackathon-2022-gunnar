export default function (context) {
    console.log(context);
    context.$vuetify.theme.dark = context.store.state.isDarkTheme;
}