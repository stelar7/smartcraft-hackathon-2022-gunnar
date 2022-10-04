export default function (context) {
    context.$vuetify.theme.dark = context.store.state.isDarkTheme;
}