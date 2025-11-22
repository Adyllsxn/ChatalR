export const headerStyles = {
  // ... (seus estilos anteriores do header)
};

export const footerStyles = {
  // Footer principal
  footer: "bg-gradient-to-br from-gray-900 via-black to-gray-800 text-white relative overflow-hidden",
  
  // Background decorativo
  background: "absolute inset-0 bg-[radial-gradient(ellipse_at_center,_var(--tw-gradient-stops))] from-orange-500/10 via-transparent to-transparent",
  
  // Container principal
  container: "max-w-7xl mx-auto px-6 py-16 relative z-10",
  
  // Grid do conteúdo
  grid: "grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-10 lg:gap-8",
  
  // Logo section
  logoSection: "lg:col-span-1",
  logo: "text-3xl font-black bg-gradient-to-r from-orange-400 to-amber-500 bg-clip-text text-transparent mb-4",
  tagline: "text-gray-300 text-lg leading-relaxed mb-6 max-w-md",
  socialLinks: "flex space-x-4",
  socialIcon: "w-10 h-10 bg-white/10 rounded-xl flex items-center justify-center hover:bg-orange-500 transition-all duration-300 hover:scale-110 border border-white/20",
  
  // Links sections
  linksSection: "space-y-6",
  sectionTitle: "text-xl font-bold text-white mb-6 relative inline-block",
  sectionTitleUnderline: "absolute -bottom-2 left-0 w-1/2 h-0.5 bg-orange-500",
  linkList: "space-y-3",
  link: "text-gray-300 hover:text-orange-400 transition-all duration-300 hover:translate-x-2 flex items-center group",
  linkIcon: "w-1.5 h-1.5 bg-orange-500 rounded-full mr-3 transform scale-0 group-hover:scale-100 transition-transform duration-300",
  
  // Newsletter
  newsletter: "lg:col-span-2 space-y-6",
  newsletterTitle: "text-2xl font-bold text-white mb-2",
  newsletterText: "text-gray-300 mb-6",
  form: "flex flex-col sm:flex-row gap-4",
  input: "flex-1 px-4 py-3 bg-white/10 border border-white/20 rounded-xl text-white placeholder-gray-400 focus:outline-none focus:border-orange-500 transition-all duration-300",
  button: "px-8 py-3 bg-gradient-to-r from-orange-500 to-amber-600 text-white font-semibold rounded-xl hover:shadow-2xl hover:shadow-orange-500/30 transition-all duration-300 transform hover:scale-105",
  
  // Bottom section
  bottom: "border-t border-white/10 mt-12 pt-8 flex flex-col lg:flex-row items-center justify-between",
  copyright: "text-gray-400 text-sm mb-4 lg:mb-0",
  bottomLinks: "flex space-x-6",
  bottomLink: "text-gray-400 hover:text-orange-400 text-sm transition-colors duration-300",
  
  // Efeitos decorativos
  ornament: "absolute -top-20 -right-20 w-40 h-40 bg-orange-500/20 rounded-full blur-3xl",
  ornament2: "absolute -bottom-20 -left-20 w-40 h-40 bg-amber-500/20 rounded-full blur-3xl"
};